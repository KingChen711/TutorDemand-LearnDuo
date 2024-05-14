using K17221TutorDemand.Models.Attributes;
using K17221TutorDemand.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Post
{
    [Key] public int Id { get; set; }

    public Guid PostId { get; set; }

    public Guid TutorId { get; set; }

    public Guid SubjectId { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Giá mỗi giờ phải lớn không 0")]
    [DisplayName("Giá mỗi giờ")]
    public int PricePerHour { get; set; }

    [MaxLength(10000, ErrorMessage = "Mô tả tối đa 10,000 kí tự")]
    [DisplayName("Mô tả")]
    public string? Description { get; set; } //Describe about the tutor's service

    [MaxLength(500)]
    [DisplayName("Video")]
    public string? Video { get; set; } //advertising video url

    [MaxLength(3000)]
    [IsSerializedArrayOfUrls]
    [DisplayName("Hình ảnh")]
    public string Images { get; set; } = "[]"; // /advertising image urls, string of serialized array urls, max 6

    [EnumDataType(typeof(PostStatus))]
    [DisplayName("Trạng thái")]
    [MaxLength(10)] //Pending, Enable, Disable
    public required string Status { get; set; }

    //navigator
    public User Tutor { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
    public ICollection<Reservation> Reservations = [];
    public ICollection<Comment> Comments = [];
    public ICollection<User> LikeUsers { get; set; } = [];
}