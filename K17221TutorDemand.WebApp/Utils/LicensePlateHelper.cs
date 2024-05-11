namespace K17221TutorDemand.Web;

public static class LicensePlateHelper
{
    public static string GenerateLicensePlate(Random random)
    {
        int firstDigits = random.Next(10, 70);
        char firstLetter = (char)random.Next('A', 'Z' + 1);
        int secondDigits = random.Next(100, 999);
        int lastDigits = random.Next(10, 99);

        // Construct the license plate string
        return $"{firstDigits}{firstLetter}-{secondDigits}.{lastDigits}";
    }
}

