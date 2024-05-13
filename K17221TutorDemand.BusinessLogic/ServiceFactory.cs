using FluentEmail.Core;
using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace K17221TutorDemand.BusinessLogic;

public class ServiceFactory : IServiceFactory
{
    private readonly Lazy<IEmailSender> _emailService;
    private readonly Lazy<IHubService> _hubService;
    private readonly Lazy<IProfileService> _profileService;

    public ServiceFactory(
        IUnitOfWork unitOfWork,
        IFluentEmail fluentEmail
    )
    {
        _emailService = new Lazy<IEmailSender>(() => new EmailService(fluentEmail));
        _hubService = new Lazy<IHubService>(() => new HubService(unitOfWork));
        _profileService = new Lazy<IProfileService>(() => new ProfileService(unitOfWork));
    }

    public IEmailSender Email => _emailService.Value;
    public IHubService Hub => _hubService.Value;
    public IProfileService Profile => _profileService.Value;
}