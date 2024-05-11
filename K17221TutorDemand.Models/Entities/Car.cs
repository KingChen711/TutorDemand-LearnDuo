using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using K17221TutorDemand.Models.Attributes;

namespace K17221TutorDemand.Models.Entities;

public class Car
{
    [Key] public int Id { get; set; }

    public Guid CarId { get; set; } //UNIQUE

    [MaxLength(20)]
    [DisplayName("Brand name")]
    public string? Brand { get; set; }

    [MaxLength(20)] public string? Color { get; set; }

    [Range(1900, int.MaxValue, ErrorMessage = "Year must be between 1900 and current year")]
    public int? Year { get; set; }

    [IsSeat] public int? Seat { get; set; }

    [MaxLength(20)] public string? Model { get; set; }

    [Required]
    [MaxLength(20)]
    [DisplayName("License plate")]
    public string LicensePlate { get; set; } = null!; //biển số xe

    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    [IsSerializedArrayOfUrls]
    public string Images { get; set; } = "[]";

    [DisplayName("Status")] public Guid CarStatusId { get; set; }

    //navigator
    public CarStatus CarStatus { get; set; } = null!;
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}