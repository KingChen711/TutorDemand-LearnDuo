using CloudinaryDotNet;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.DataAccess
{
    public class ImagesRepository : GenericRepository<Post>, IImagesRepository
    {
        private readonly TutorDemandDbContext context;
        private readonly IConfiguration configuration;

        public ImagesRepository(TutorDemandDbContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
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
