using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface IUserService
{
    Task<User?> GetUserById(Guid userId, bool trackChanges);
}