using K17221TutorDemand.DataAccess.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace K17221TutorDemand.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ImageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageUrl = await unitOfWork.Images.UploadAsync(file);
            if (imageUrl == null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }
            return Ok(new { link = imageUrl });
        }
    }
}
