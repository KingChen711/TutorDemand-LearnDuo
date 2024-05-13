using System.ComponentModel.DataAnnotations;
using K17221TutorDemand.Models.Dtos.Profile;
using Microsoft.AspNetCore.Identity;

namespace K17221TutorDemand.Models.Dtos.User;

public record UserWithProfileDto
{
    public Guid UserId { get; set; }

    public string FullName { get; set; } = null!;

    public ProfileDto Profile { get; set; } = null!;
}