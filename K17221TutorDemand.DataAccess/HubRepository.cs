using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace K17221TutorDemand.DataAccess;

public class HubRepository : GenericRepository<Hub>, IHubRepository
{
    public HubRepository(TutorDemandDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Hub>> GetUserHubs(Guid userId)
    {
        var hubs = await
            FindByCondition(
                    h =>
                        h.Users.Select(u => u.UserId).Contains(userId), false
                )
                .OrderByDescending(h => h.LastMessageAt)
                .Take(20) //Get max 20 recent conservation, another will be get by client side with infinity scrolling technique 
                .Include(h => h.Messages.OrderByDescending(m => m.CreatedAt).Take(1))
                .ThenInclude(m => m.Sender)
                .ThenInclude(u => u.Profile)
                .ToListAsync();

        return hubs;
    }

    public async Task<Guid?> GetHubIdByUserIds(Guid userId1, Guid userId2)
    {
        var hub = await
            FindByCondition(
                    h =>
                        h.Users.Select(u => u.UserId).Contains(userId1) &&
                        h.Users.Select(u => u.UserId).Contains(userId2),
                    false)
                .SingleOrDefaultAsync();

        return hub?.HubId;
    }

    public async Task<bool> CheckUserBelongToHub(Guid hubId, Guid userId)
    {
        var hub = await
            FindByCondition(h => h.HubId == hubId, false)
                .Include(h => h.Users)
                .FirstOrDefaultAsync();

        return hub?.Users.Select(u => u.UserId).Contains(userId) ?? false;
    }

    public async Task<Hub?> GetHubDetailById(Guid hubId, Guid userId)
    {
        var hub = await
            FindByCondition(h => h.HubId == hubId, false)
                .Include(h => h.Users.Where(u => u.UserId != userId)) //get the other user
                .ThenInclude(u => u.Profile)
                .Include(h =>
                        h.Messages
                            .OrderByDescending(m => m.CreatedAt)
                            .Take(30) //just take the first 30 messages, using infinity scrolling technique for load more
                )
                .FirstOrDefaultAsync();

        return hub;
    }
}