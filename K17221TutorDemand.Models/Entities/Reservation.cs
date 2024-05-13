using K17221TutorDemand.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Reservation
{
    [Key] public int Id { get; set; }

    public Guid ReservationId { get; set; }

    public Guid CustomerId { get; set; }

    public Guid PostId { get; set; }

    [EnumDataType(typeof(ReservationStatus))]
    [DisplayName("Trạng thái")]
    [MaxLength(15)] //Pending, Completed, Canceled, Processing
    public required string Status { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Số giờ thuê tối thiểu là 1 giờ.")]
    [DisplayName("Số giờ thuê")]
    public int TeachingDuration { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Chi phí thuê phải lớn hơn không.")]
    [DisplayName("Chi phí")]
    public int PaidPrice { get; set; } //field này có hiện trên UI nhưng disable

    public DateTime CreatedAt;

    public DateTime? StartAt; //bắt đầu khi tutor approve reservation 

    public DateTime? EndAt; //kết thúc khi customer xác nhận hoàn thành, hoặc tự động kết thúc sau 24h và phạt tutor vì không nhắc customer xác nhận hoàn thành (dựa theo phỏng vấn)

    //navigator
    public Post Post { get; set; } = null!;
    public User Customer { get; set; } = null!;
    public Feedback? Feedback { get; set; } = null!;
}