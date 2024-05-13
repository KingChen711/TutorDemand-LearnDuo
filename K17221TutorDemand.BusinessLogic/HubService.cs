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

    public async Task<List<HubWithLastMessageDto>> GetUserHubs(Guid userId)
    {
        var hubs = await _unitOfWork.Hub.GetUserHubs(userId);
        return hubs.Adapt<List<HubWithLastMessageDto>>();
    }

    public async Task<Guid?> GetHubIdByUserIds(Guid userId1, Guid userId2)
    {
        if (!await CheckExistUsers(userId1, userId2))
        {
            return null;
        }

        return await _unitOfWork.Hub.GetHubIdByUserIds(userId1, userId2);
    }

    public async Task<Hub> CreateHub(Guid userId1, Guid userId2)
    {
        var user1 = await _unitOfWork.User.GetUserById(userId1, true);
        var user2 = await _unitOfWork.User.GetUserById(userId2, true);

        if (user1 is null || user2 is null)
        {
            throw new Exception("Some user not exists");
        }

        var hub = new Hub();
        _unitOfWork.Hub.Create(hub);
        await _unitOfWork.SaveAsync();

        user1.Hubs.Add(hub);
        user2.Hubs.Add(hub);
        await _unitOfWork.SaveAsync();

        return hub;
    }

    public async Task<HubDetailDto?> GetHubDetailById(Guid hubId, Guid userId)
    {
        if (!await _unitOfWork.Hub.CheckUserBelongToHub(hubId, userId))
        {
            throw new Exception("User not belong to this hub");
        }

        var hub = await _unitOfWork.Hub.GetHubDetailById(hubId, userId);
        
        return hub.Adapt<HubDetailDto>();
    }

    private async Task<bool> CheckExistUsers(Guid userId1, Guid userId2)
    {
        if (!await _unitOfWork.User.AnyAsync(u => u.UserId == userId1))
        {
            return false;
        }

        if (!await _unitOfWork.User.AnyAsync(u => u.UserId == userId2))
        {
            return false;
        }

        return true;
    }
}