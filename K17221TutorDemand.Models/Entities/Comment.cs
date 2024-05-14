using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Comment
{
    [Key] public int Id { get; set; }

    public Guid CommentId { get; set; }

    public Guid UserId { get; set; }

    public Guid PostId { get; set; }

    [MaxLength(500)]
    [DisplayName("Bình luận")]
    public string? Content { get; set; }

    [MaxLength(500)]
    [DisplayName("Bình luận")]
    public string? Image { get; set; }
    
    //navigator
    public User User { get; set; } = null!;
    public Post Post { get; set; } = null!;
    public ICollection<User> LikeUsers { get; set; } = [];
}