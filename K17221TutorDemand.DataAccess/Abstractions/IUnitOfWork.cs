namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IUnitOfWork
{
    IHubRepository Hub { get; }
    IUserRepository User { get; }
    Task SaveAsync();
}