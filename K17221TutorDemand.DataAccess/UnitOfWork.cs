using K17221TutorDemand.DataAccess.Abstractions;

namespace K17221TutorDemand.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TutorDemandDbContext _context;
        private readonly Lazy<IHubRepository> _hubRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public UnitOfWork(TutorDemandDbContext context)
        {
            _context = context;
            _hubRepository = new Lazy<IHubRepository>(() => new
                HubRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new
                UserRepository(context));
        }

        public IHubRepository Hub => _hubRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}