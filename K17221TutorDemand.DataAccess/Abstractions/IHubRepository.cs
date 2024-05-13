using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IHubRepository : IGenericRepository<Hub>
{
    Task<IEnumerable<Hub>> GetUserHubs(Guid userId);
    Task<Guid?> GetHubIdByUserIds(Guid userId1, Guid userId2);
    void CreateHub(Hub hub);
}