namespace K17221TutorDemand.Models.Dtos.Message;

public record MessageDto
{
    public Guid MessageId { get; set; }

    public Guid ReceiverId { get; set; }

    public Guid SenderId { get; set; }

    public Guid HubId { get; set; }

    public string? Content { get; set; }

    public string? Video { get; set; }

    public string? Image { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsSeen { get; set; } = false;
}