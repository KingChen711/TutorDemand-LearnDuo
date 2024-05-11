using Microsoft.AspNetCore.Identity;

namespace K17221TutorDemand.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public Guid UserId { get; set; }
    }
}
