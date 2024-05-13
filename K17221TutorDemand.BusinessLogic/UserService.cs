using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.BusinessLogic;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User?> GetUserById(Guid userId, bool trackChanges)
    {
        return await _unitOfWork.User.GetUserById(userId, trackChanges);
    }
}