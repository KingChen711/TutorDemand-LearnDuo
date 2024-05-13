using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.Models.Dtos.Hub;

public record HubWithLastMessageDto
{
    public Guid HubId { get; set; }

    public DateTime CreatedAt { get; set; }

    public MessageWithSenderDto? LastMessage { get; set; } = null!;
}

public record MessageWithSenderDto
{
    public int Id { get; set; }

    public Guid MessageId { get; set; }

    public Guid ReceiverId { get; set; }

    public Guid SenderId { get; set; }

    public string? Content { get; set; }

    public string? Video { get; set; }

    public string? Image { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsSeen { get; set; } = false;
    public string SenderName { get; set; } = null!;
}