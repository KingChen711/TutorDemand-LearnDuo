using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace K17221TutorDemand.DataAccess;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(TutorDemandDbContext context) : base(context)
    {
    }

    public async Task<User?> GetUserById(Guid userId, bool trackChanges)
    {
        return await FindByCondition(u => u.UserId == userId, trackChanges).FirstOrDefaultAsync();
    }
}