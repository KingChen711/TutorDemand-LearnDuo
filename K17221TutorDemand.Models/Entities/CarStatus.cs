using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class CarStatus
{
    [Key] public int Id { get; set; }

    public Guid CarStatusId { get; set; } //UNIQUE

    [DisplayName("Status name")]
    [MaxLength(20)]
    public string Name { get; set; } = null!; //UNIQUE

    //navigator
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}