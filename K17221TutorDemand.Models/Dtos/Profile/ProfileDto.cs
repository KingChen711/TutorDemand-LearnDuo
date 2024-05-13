namespace K17221TutorDemand.Models.Dtos.Profile;

public record ProfileDto
{
    public string Avatar { get; set; } = "/images/default-avatar.jpg";

    public string Album { get; set; } = "[]"; // string of serialized array urls, max 6

    public string? Nickname { get; set; }

    public string? Bio { get; set; }

    public string? Gender { get; set; }

    public bool IsAvailable { get; set; } //only tutor uses this prop

    public string? AutomaticGreeting { get; set; }
}