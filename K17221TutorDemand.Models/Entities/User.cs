using Microsoft.AspNetCore.Identity;

namespace K17221TutorDemand.Models.Entities;

public class User : IdentityUser<int>
{
    public Guid UserId { get; set; }

    //navigator
    public Profile Profile { get; set; } = null!;
    public ICollection<Hub> Hubs { get; set; } = [];
    public ICollection<Post> Posts { get; set; } = []; //only for tutor role
    public ICollection<Reservation> Reservations = [];
    public ICollection<Message> ReceivedMessages = [];
    public ICollection<Message> SendMessages = [];
}


