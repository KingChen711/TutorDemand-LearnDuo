using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.BusinessLogic.Abstractions;

public interface ICarService
{
    Task<IEnumerable<Car>> GetAllCars(bool trackChanges);
}