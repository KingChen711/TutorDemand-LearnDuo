using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace K17221TutorDemand.DataAccess;

public class HubRepository : GenericRepository<Hub>, IHubRepository
{
    private readonly TutorDemandDbContext _context;

    public HubRepository(TutorDemandDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Hub>> GetUserHubs(Guid userId)
    {
        var user = await _context.Users
            .AsNoTracking()
            .Where(u => u.UserId == userId)
            .Include(u =>
                    u.Hubs
                        .OrderByDescending(h => h.LastMessageAt)
                        .Take(20) //Get max 20 recent conservation, another will be get by client side with infinity scrolling technique 
            )
            .ThenInclude(h => h.Messages.OrderByDescending(m => m.CreatedAt).Take(1)) //take the last message
            .ThenInclude(m => m.Sender)
            .FirstOrDefaultAsync();

        if (user is null) return [];

        return user.Hubs;
    }

    public async Task<Guid?> GetHubIdByUserIds(Guid userId1, Guid userId2)
    {
        var hub = await FindByCondition(
                h =>
                    h.Users.Select(u => u.UserId).Contains(userId1) &&
                    h.Users.Select(u => u.UserId).Contains(userId2),
                false)
            .SingleOrDefaultAsync();

        return hub?.HubId;
    }

    public void CreateHub(Hub hub)
    {
        Create(hub);
    }
}