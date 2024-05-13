using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.BusinessLogic;

public class ProfileService : IProfileService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProfileService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateDefaultProfile(Guid userId)
    {
        _unitOfWork.Profile.Create(new Profile { UserId = userId });

        await _unitOfWork.SaveAsync();
    }
}