using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IHubRepository : IGenericRepository<Hub>
{
    Task<IEnumerable<Hub>> GetUserHubs(Guid userId);
    Task<Guid?> GetHubIdByUserIds(Guid userId1, Guid userId2);
    Task<bool> CheckUserBelongToHub(Guid hubId, Guid userId);
    Task<Hub?> GetHubDetailById(Guid hubId, Guid userId);
}