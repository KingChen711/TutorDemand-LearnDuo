using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class Contract
{
    [Key] public int Id { get; set; }

    public Guid ContractId { get; set; } //UNIQUE

    public Guid CustomerId { get; set; }

    public Guid CarId { get; set; }

    public Guid ContractStatusId { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "Car owner")]
    public string CarOwner { get; set; } = "Công Ty Car Renting"; //*Chủ xe chưa chắc là tiệm cho thuê xe.

    [Required]
    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Required]
    [Display(Name = "End date")]
    public DateTime EndDate { get; set; } //TODO:nhớ check logic giữa start date và end date ở tầng business logic

    [Required] [Range(0, int.MaxValue)] public int Cost { get; set; } //*VNĐ nên là để integer thấy ổn

    //navigator
    public Car Car { get; set; } = null!;
    public User Customer { get; set; } = null!;
    public ContractStatus ContractStatus { get; set; } = null!;
    public Payment? Payment { get; set; } = null!;
    public Feedback? Feedback { get; set; } = null!;
}