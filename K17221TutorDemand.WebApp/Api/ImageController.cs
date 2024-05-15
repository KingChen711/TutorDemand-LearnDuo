using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace K17221TutorDemand.WebApp.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IServiceFactory serviceFactory;

        public ImageController(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageUrl = await serviceFactory.Image.UploadAsync(file);
            if (imageUrl == null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }
            return Ok(new { link = imageUrl });
        }
    }
}
