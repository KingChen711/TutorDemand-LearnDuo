namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IUnitOfWork
{
    ICarRepository Car { get; }
    Task SaveAsync();
}