using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Feedback
{
    [Key] public int Id { get; set; }

    public Guid ContractId { get; set; } //UNIQUE: Không tự sinh mà luôn sinh từ 1 contract nào đó của customer, one to one, với một contract hoàn thành, customer chỉ được feedback 1 lần, nhưng vẫn có thể chỉnh sửa nội dung feedback nếu muốn. Để feedback, customer nên xuất phát từ màn quản lý các contracts của customer, giúp cho BE dễ tạo feedback.

    [Range(1, 5, ErrorMessage = "Rate value should be between 1 and 5")]
    public int Rate { get; set; }

    [MaxLength(1000, ErrorMessage = "Comment should be less than 1000 characters")]
    public string? Comment { get; set; }

    //navigator
    public Contract Contract { get; set; } = null!;
}