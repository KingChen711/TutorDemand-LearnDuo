using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.Models.Dtos.Post
{
    public class AddPostDto
    {
        public string TutorId { get; set; }
        public string SubjectId { get; set; } = "33F9036D-E83B-45ED-BB5B-95308ECB7478";
        public string? Description { get; set; }
        public string Images { get; set; } = "[]";
        public string? Video { get; set; }
        public int PricePerHour { get; set; }
    }
}
