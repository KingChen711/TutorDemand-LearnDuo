using K17221TutorDemand.Models.Attributes;
using K17221TutorDemand.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Profile
{
    [Key]
    public int Id { get; set; }

    public Guid UserId { get; set; }

    [MaxLength(500)]
    [DisplayName("Ảnh đại diện")]
    public string Avatar { get; set; } = "/images/default-avatar.jpg";

    [MaxLength(3000)]
    [IsSerializedArrayOfUrls]
    public string Album { get; set; } = "[]"; // string of serialized array urls, max 6

    [DisplayName("Biệt danh")]
    [MaxLength(100, ErrorMessage = "Biệt danh tối đa 100 kí tự")]
    public string? Nickname { get; set; }

    [DisplayName("Lý lịch")]
    [MaxLength(3000, ErrorMessage = "Lý lịch tối đa 3000 kí tự")]
    public string? Bio { get; set; }

    [EnumDataType(typeof(Gender))]
    [DisplayName("Giới tính")]
    [MaxLength(10)] //Male,Female,Other
    public string? Gender { get; set; }

    public bool IsAvailable { get; set; } //only tutor uses this prop

    [DisplayName("Lời chào tự động")]
    [MaxLength(1000, ErrorMessage = "Lời chào tự động tối đa 1000 kí tự")]
    public string? AutomaticGreeting { get; set; }

    //navigator
    public User User { get; set; } = null!;
}

