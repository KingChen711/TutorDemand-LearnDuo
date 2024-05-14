using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Enums;

public enum RoleAccount
{
    Student,
    Tutor,
    Moderator,
    Administrator,
    //[Display(Name = "System Handler")]
    SystemHandler
}