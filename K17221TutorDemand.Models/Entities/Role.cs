using Microsoft.AspNetCore.Identity;

namespace K17221TutorDemand.Models.Entities;

public class Role : IdentityRole<int>
{
    public Guid RoleId { get; set; }
}