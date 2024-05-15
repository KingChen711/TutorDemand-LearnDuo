using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.DataAccess
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(TutorDemandDbContext context) : base(context)
        {
        }
    }
}
