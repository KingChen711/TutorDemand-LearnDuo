using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetUserById(Guid userId, bool trackChanges);
}