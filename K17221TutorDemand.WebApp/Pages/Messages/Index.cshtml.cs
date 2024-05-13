using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.Models.Dtos.Hub;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace K17221TutorDemand.WebApp.Pages.Messages;

public class Index : PageModel
{
    private IServiceFactory _service;
    private readonly UserManager<IdentityUser> _userManager;

    public Index(IServiceFactory service)
    {
        _service = service;
    }

    public IEnumerable<HubWithLastMessageDto> Hubs = [];

    public async Task<IActionResult?> OnGetAsync(Guid? hubId)
    {
        var userIdClaim = User.FindFirstValue("UserId");

        if (User.Identity is null || !User.Identity.IsAuthenticated || userIdClaim is null)
        {
            return RedirectToPage("/Account/Login");
        }

        var userId = Guid.Parse(userIdClaim);

        Hubs = await _service.Hub.GetUserHubs(userId);

        return Page();
    }
}