namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IUnitOfWork
{
    IHubRepository Hub { get; }
    IProfileRepository Profile { get; }
    IUserRepository User { get; }
    IMessageRepository Message { get; }
    Task SaveAsync();
}