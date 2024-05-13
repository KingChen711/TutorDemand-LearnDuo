using K17221TutorDemand.Models.Dtos.Hub;
using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface IHubService
{
    Task<IEnumerable<HubWithLastMessageDto>> GetUserHubs(Guid userId);
}