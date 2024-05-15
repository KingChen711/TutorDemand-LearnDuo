using Microsoft.AspNetCore.Identity.UI.Services;

namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface IServiceFactory
{
    IHubService Hub { get; }
    IProfileService Profile { get; }
    IEmailSender Email { get; }
    IPostService Post { get; }
    IImageService Image { get; }
    ISubjectService Subject { get; }
}