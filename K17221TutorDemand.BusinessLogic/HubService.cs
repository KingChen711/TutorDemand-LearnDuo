using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Dtos.Hub;
using K17221TutorDemand.Models.Entities;
using Mapster;

namespace K17221TutorDemand.BusinessLogic;

public class HubService : IHubService
{
    private readonly IUnitOfWork _unitOfWork;

    public HubService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<HubWithLastMessageDto>> GetUserHubs(Guid userId)
    {
        var hubs = await _unitOfWork.Hub.GetUserHubs(userId);
        return hubs.Adapt<IEnumerable<HubWithLastMessageDto>>();
    }
}