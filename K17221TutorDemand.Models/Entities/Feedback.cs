using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Feedback
{
    [Key] public int Id { get; set; }

    public Guid ReservationId { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Đánh giá phải từ 1 đến 5 sao.")]
    [DisplayName("Chất lượng buổi học")]
    public int RateValue { get; set; }

    [DisplayName("Nội dung đánh giá")]
    [MaxLength(10000)]
    public string? Content { get; set; }

    //navigator
    public Reservation Reservation { get; set; } = null!;
}