using K17221TutorDemand.Models.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.BusinessLogic.Abstractions
{
    public interface IPostService
    {
        Task CreatePost(AddPostDto addPostDto);
    }
}
