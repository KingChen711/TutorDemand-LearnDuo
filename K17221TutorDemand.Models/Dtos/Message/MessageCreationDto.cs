using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Dtos.Message;

public record MessageCreationDto
{
    public Guid ReceiverId { get; set; }

    public Guid SenderId { get; set; }

    public Guid HubId { get; set; }

    [MaxLength(3000)] public string? Content { get; set; }

    [MaxLength(500)] public string? Video { get; set; }

    [MaxLength(500)] public string? Image { get; set; }

    //Content, Video và Image có đều có thể null nhưng cần validate buộc phải có 1 trong 3 prop này
}