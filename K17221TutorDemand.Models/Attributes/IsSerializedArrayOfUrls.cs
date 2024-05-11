using System.ComponentModel.DataAnnotations;

namespace K17221TutorDemand.Models.Attributes;

public class IsSerializedArrayOfUrlsAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult($"{validationContext.DisplayName} is not null.");
        }

        if (!(value is string stringValue))
        {
            return new ValidationResult($"{validationContext.DisplayName} must be a string.");
        }

        if (!IsSerializedArrayOfUrls(stringValue))
        {
            return new ValidationResult($"{validationContext.DisplayName} is not a valid serialized array of URLs.");
        }

        return ValidationResult.Success;
    }

    private bool IsSerializedArrayOfUrls(string value)
    {
        // Check if the string starts with '[' and ends with ']'
        if (!value.StartsWith("[") || !value.EndsWith("]"))
        {
            return false;
        }

        // Remove the brackets
        string urlsString = value[1..^1];

        if (urlsString == "") return true; //case: "[]"

        // Split the string by ','
        string[] urls = urlsString.Split(',');

        foreach (var url in urls)
        {
            // Trim each URL to remove any leading or trailing whitespace
            string trimmedUrl = url.Trim();

            // Check if the trimmed URL is a valid absolute URL
            if (!Uri.TryCreate(trimmedUrl, UriKind.Absolute, out _))
            {
                return false;
            }
        }

        return true;
    }
}