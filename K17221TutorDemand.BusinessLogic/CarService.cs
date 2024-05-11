using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.BusinessLogic;

public class CarService : ICarService
{
    private readonly IUnitOfWork _unitOfWork;

    public CarService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Car>> GetAllCars(bool trackChanges)
    {
        return await _unitOfWork.Car.GetAllCars(trackChanges);
    }
}