using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.Models.Dtos.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace K17221TutorDemand.WebApp.Pages.Posts
{
    public class AddPostModel : PageModel
    {
        private readonly IServiceFactory serviceFactory;

        public AddPostModel(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        [BindProperty]
        public AddPostDto AddPostRequest { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            await serviceFactory.Post.CreatePost(AddPostRequest);
            return Page();
        }
    }
}
