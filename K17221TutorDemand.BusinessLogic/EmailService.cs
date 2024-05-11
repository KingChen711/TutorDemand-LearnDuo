using K17221TutorDemand.Models.Entities;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace K17221TutorDemand.BusinessLogic;

public class EmailService : IEmailSender
{
    private readonly IFluentEmail _fluentEmail;

    public EmailService(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        await _fluentEmail
            .To(toEmail)
            .Subject(subject)
            .Body(message, true)
            .SendAsync();
    }
}