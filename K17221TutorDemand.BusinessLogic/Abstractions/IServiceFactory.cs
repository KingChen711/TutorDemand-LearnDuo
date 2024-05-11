using Microsoft.AspNetCore.Identity.UI.Services;

namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface IServiceFactory
{
    IEmailSender Email { get; }
}