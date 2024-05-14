using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Dtos.Post;
using K17221TutorDemand.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.BusinessLogic
{
    public class PostService : IPostService
    {
        private IUnitOfWork unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreatePost(AddPostDto addPostDto)
        {
            var post = new Post()
            {
                PostId = new Guid(),
                TutorId = Guid.Parse(addPostDto.TutorId),
                SubjectId = Guid.Parse(addPostDto.SubjectId),
                Description = addPostDto.Description,
                Images = addPostDto.Images,
                PricePerHour = addPostDto.PricePerHour,
                Status = "Pending"
            };
            unitOfWork.Post.CreatePost(post);
            await unitOfWork.SaveAsync();
        }
    }
}
