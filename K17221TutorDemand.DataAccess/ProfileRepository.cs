using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;

namespace K17221TutorDemand.DataAccess;

public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
{
    public ProfileRepository(TutorDemandDbContext context) : base(context)
    {
    }
}