using K17221TutorDemand.DataAccess.Abstractions;

namespace K17221TutorDemand.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TutorDemandDbContext _context;

        public UnitOfWork(TutorDemandDbContext context)
        {
            _context = context;
        }

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}