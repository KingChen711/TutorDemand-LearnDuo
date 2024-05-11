using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Entities;

public class ContractStatus
{
    [Key] public int Id { get; set; }

    public Guid ContractStatusId { get; set; }

    [DisplayName("Status name")]
    [MaxLength(20)]
    public string Name { get; set; } = null!; //UNIQUE

    //navigator
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}