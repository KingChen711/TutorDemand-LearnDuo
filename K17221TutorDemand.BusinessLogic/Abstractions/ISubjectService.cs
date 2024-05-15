using K17221TutorDemand.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.BusinessLogic.Abstractions
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAll();
    }
}
