using System.Security.Claims;
using K17221TutorDemand.BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace K17221TutorDemand.WebApp.Pages.Messages
{
    public class ChatModel : PageModel
    {
        private readonly IServiceFactory _service;

        public ChatModel(IServiceFactory service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(Guid? otherUserId)
        {
            if (otherUserId is null)
            {
                return NotFound();
            }

            var userIdClaim = User.FindFirstValue("UserId");

            if (User.Identity is null || !User.Identity.IsAuthenticated || userIdClaim is null)
            {
                return RedirectToPage("/Account/Login");
            }

            var userId = Guid.Parse(userIdClaim);

            if (otherUserId == userId)
            {
                return NotFound();
            }

            var hubId = await _service.Hub.GetHubIdByUserIds(userId, (Guid)otherUserId);

            if (hubId is not null)
            {
                return RedirectToPage("/Messages/Index", new { hubId = (Guid)hubId });
            }

            try
            {
                var hub = await _service.Hub.CreateHub(userId, (Guid)otherUserId);
                return RedirectToPage("/Messages/Index", new { hubId = hub.HubId });
            }
            catch (Exception e)
            {
                //error when other user is invalid
                return NotFound();
            }
        }
    }
}