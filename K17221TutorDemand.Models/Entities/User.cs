using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace K17221TutorDemand.Models.Entities;

public class User : IdentityUser<int>
{
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Tên tối đa 50 kí tự")]
    public string FullName { get; set; } = null!;

    //navigator
    public Profile Profile { get; set; } = null!;
    public ICollection<Hub> Hubs { get; set; } = [];
    public ICollection<Post> Posts { get; set; } = []; //only for tutor role
    public ICollection<Reservation> Reservations = [];
    public ICollection<Message> ReceivedMessages = [];
    public ICollection<Message> SendMessages = [];
    public ICollection<Comment> Comments = [];
    public ICollection<Comment> LikeComments = [];
    public ICollection<Post> LikePosts = [];
}