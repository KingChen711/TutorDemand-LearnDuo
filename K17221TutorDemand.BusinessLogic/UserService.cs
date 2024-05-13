using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace K17221TutorDemand.BusinessLogic;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public Task<User?> GetCurrentUser()
    {
        throw new NotImplementedException();
    }
}