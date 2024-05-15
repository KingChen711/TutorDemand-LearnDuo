using FluentEmail.Core;
using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace K17221TutorDemand.BusinessLogic;

public class ServiceFactory : IServiceFactory
{
    private readonly Lazy<IEmailSender> _emailService;
    private readonly Lazy<IHubService> _hubService;
    private readonly Lazy<IProfileService> _profileService;
    private readonly Lazy<IPostService> _postService;
    private readonly Lazy<IImageService> _imageService;
    private readonly Lazy<ISubjectService> _subjectService;

    public ServiceFactory(
        IUnitOfWork unitOfWork,
        IFluentEmail fluentEmail,
        IConfiguration configuration
    )
    {
        _emailService = new Lazy<IEmailSender>(() => new EmailService(fluentEmail));
        _hubService = new Lazy<IHubService>(() => new HubService(unitOfWork));
        _profileService = new Lazy<IProfileService>(() => new ProfileService(unitOfWork));
        _postService = new Lazy<IPostService>(() => new PostService(unitOfWork));
        _subjectService = new Lazy<ISubjectService>(() => new SubjectService(unitOfWork));
        _imageService = new Lazy<IImageService>(() => new ImageService(unitOfWork, configuration));
    }

    public IEmailSender Email => _emailService.Value;
    public IHubService Hub => _hubService.Value;
    public IProfileService Profile => _profileService.Value;
    public IPostService Post => _postService.Value;

    public IImageService Image => _imageService.Value;

    public ISubjectService Subject => _subjectService.Value;
}