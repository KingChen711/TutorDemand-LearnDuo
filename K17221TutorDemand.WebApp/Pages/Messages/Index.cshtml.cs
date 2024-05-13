using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.Models.Dtos.Hub;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using K17221TutorDemand.Models.Entities;
using Microsoft.IdentityModel.Tokens;

namespace K17221TutorDemand.WebApp.Pages.Messages;

public class Index : PageModel
{
    private IServiceFactory _service;

    public Index(IServiceFactory service)
    {
        _service = service;
    }

    public List<HubWithLastMessageDto> Hubs = [];
    public Hub? ActiveHub;

    public async Task<IActionResult> OnGetAsync(Guid? hubId)
    {
        var userIdClaim = User.FindFirstValue("UserId");

        if (User.Identity is null || !User.Identity.IsAuthenticated || userIdClaim is null)
        {
            return RedirectToPage("/Account/Login");
        }

        var userId = Guid.Parse(userIdClaim);

        Hubs = await _service.Hub.GetUserHubs(userId);

        if (Hubs.IsNullOrEmpty())
        {
            return Page();
        }

        //hubId null is not the problem, just using the last hub
        var activeHubId = hubId ?? Hubs[0].HubId;

        return Page();
    }
}