using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.DataAccess.Abstractions;

public interface ICarRepository : IGenericRepository<Car>
{
    Task<IEnumerable<Car>> GetAllCars(bool trackChanges);
}