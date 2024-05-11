using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Payment
{
    [Key] public int Id { get; set; }

    public Guid ContractId { get; set; } //UNIQUE: Không tự sinh mà luôn dựa vào 1 contract, one to one

    [MaxLength(20)]
    [Display(Name = "Payment Method")]
    public string PaymentMethod { get; set; } = null!; //TODO: cần xem xét

    [Range(0, int.MaxValue)]
    [Display(Name = "Rest Payment")]
    public int RestPayment { get; set; } // Do là đặt cọc, nên đặt tên prop này là rest cost

    //navigator
    public Contract Contract { get; set; } = null!;
}