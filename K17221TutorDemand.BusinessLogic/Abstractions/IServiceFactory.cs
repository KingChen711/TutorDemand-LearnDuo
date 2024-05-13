using Microsoft.AspNetCore.Identity.UI.Services;

namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface IServiceFactory
{
    IHubService Hub { get; }
    IEmailSender Email { get; }
}