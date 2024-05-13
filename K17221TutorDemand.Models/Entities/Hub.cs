using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Hub
{
    [Key] public int Id { get; set; }

    public Guid HubId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastMessageAt { get; set; } // used to sort recent conservation to the top

    //navigator
    public ICollection<User> Users { get; set; } = [];
    public ICollection<Message> Messages { get; set; } = [];
}