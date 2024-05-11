using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Attributes;

public class IsSeatAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success; // actually not need to check
        }

        if (int.TryParse(value.ToString(), out var intValue))
        {
            if (intValue != 4 && intValue != 7)
            {
                return new ValidationResult("Seat must be either 4 or 7.");
            }

            return ValidationResult.Success;
        }

        return new ValidationResult("Seat must be an integer.");
    }
}