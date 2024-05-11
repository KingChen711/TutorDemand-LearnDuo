namespace K17221TutorDemand.Models.SettingModels;

public class EmailConfiguration
{
    public string Section { get; set; } = "EmailSettings";

    public string? BusinessEmail { get; set; }
    public string? Password { get; set; }
    public int Port { get; set; }
    public string? SmtpHost { get; set; }
    public string? DefaultFromEmail { get; set; }
}