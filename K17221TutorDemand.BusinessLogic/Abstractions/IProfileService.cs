namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface IProfileService
{
    Task CreateDefaultProfile(Guid userId);
}