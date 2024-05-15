using CloudinaryDotNet;
using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.BusinessLogic
{
    public class ImageService : IImageService
    {
        private IUnitOfWork unitOfWork;
        private IConfiguration configuration;

        public ImageService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var account = new Account(configuration.GetSection("Cloundinary")["CloundName"], configuration.GetSection("Cloundinary")["ApiKey"], configuration.GetSection("Cloundinary")["ApiSecret"]);
            var client = new Cloudinary(account);
            var uploadResult = await client.UploadAsync(
                  new CloudinaryDotNet.Actions.ImageUploadParams
                  {
                      File = new FileDescription(file.FileName, file.OpenReadStream()),
                      DisplayName = file.FileName,
                      UploadPreset = "n60t718n"
                  });
            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();
            }
            return null;
        }
    }
}
