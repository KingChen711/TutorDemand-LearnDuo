using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace K17221TutorDemand.DataAccess;

public class CarRepository : GenericRepository<Car>, ICarRepository
{
    public CarRepository(TutorDemandDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Car>> GetAllCars(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
}