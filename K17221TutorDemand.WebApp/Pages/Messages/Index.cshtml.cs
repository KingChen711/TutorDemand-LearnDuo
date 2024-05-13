using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace K17221TutorDemand.WebApp.Pages.Messages;

public class Index : PageModel
{
    public IActionResult? OnGet(Guid? hubId)
    {
        if (User.Identity is null || !User.Identity.IsAuthenticated)
        {
            Console.WriteLine("test");
            return RedirectToPage("/Account/Login");
        }

        Console.WriteLine("test2");
        return null;
    }
}