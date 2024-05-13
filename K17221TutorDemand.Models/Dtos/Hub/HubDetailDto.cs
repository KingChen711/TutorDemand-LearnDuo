using K17221TutorDemand.Models.Dtos.Message;
using K17221TutorDemand.Models.Dtos.User;

namespace K17221TutorDemand.Models.Dtos.Hub;

public record HubDetailDto
{
    public Guid HubId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastMessageAt { get; set; }

    public UserWithProfileDto OtherUser { get; set; } = null!;

    public ICollection<MessageDto> Messages { get; set; } = [];
}