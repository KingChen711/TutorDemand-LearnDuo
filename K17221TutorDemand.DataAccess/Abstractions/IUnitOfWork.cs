namespace K17221TutorDemand.DataAccess.Abstractions;

public interface IUnitOfWork
{
    Task SaveAsync();
}