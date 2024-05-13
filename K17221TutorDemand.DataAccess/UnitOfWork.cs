using K17221TutorDemand.DataAccess.Abstractions;

namespace K17221TutorDemand.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TutorDemandDbContext _context;
        private readonly Lazy<IHubRepository> _hubRepository;

        public UnitOfWork(TutorDemandDbContext context)
        {
            _context = context;
            _hubRepository = new Lazy<IHubRepository>(() => new
                HubRepository(context));
        }

        public IHubRepository Hub => _hubRepository.Value;
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}