using K17221TutorDemand.Models.Dtos.Hub;
using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface IHubService
{
    Task<List<HubWithLastMessageDto>> GetUserHubs(Guid userId);
    Task<Guid?> GetHubIdByUserIds(Guid userId1, Guid userId2);
    Task<Hub> CreateHub(Guid userId1, Guid userId2);
    Task<HubDetailDto?> GetHubDetailById(Guid hubId, Guid userId);
}