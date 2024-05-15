using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.DataAccess
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(TutorDemandDbContext context) : base(context)
        {
        }

        void IPostRepository.CreatePost(Post post)
        {
            Create(post);
        }
    }
}
