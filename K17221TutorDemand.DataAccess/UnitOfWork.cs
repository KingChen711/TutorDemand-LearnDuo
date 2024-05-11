using K17221TutorDemand.DataAccess.Abstractions;

namespace K17221TutorDemand.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TutorDemandDbContext _context;
        private readonly Lazy<ICarRepository> _carRepository;

        public UnitOfWork(TutorDemandDbContext context)
        {
            _context = context;
            _carRepository = new Lazy<ICarRepository>(() => new
                CarRepository(context));
        }

        public ICarRepository Car => _carRepository.Value;
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}