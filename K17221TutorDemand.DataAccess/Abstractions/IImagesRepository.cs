using K17221TutorDemand.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.DataAccess.Abstractions
{
    public interface IImagesRepository : IGenericRepository<Post>
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
