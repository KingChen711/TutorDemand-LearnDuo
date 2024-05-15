using K17221TutorDemand.BusinessLogic.Abstractions;
using K17221TutorDemand.DataAccess.Abstractions;
using K17221TutorDemand.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K17221TutorDemand.BusinessLogic
{
    public class SubjectService : ISubjectService
    {
        private IUnitOfWork unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Subject>> GetAll()
        {
            return (Task<IEnumerable<Subject>>)unitOfWork.Subject.FindAll(false);
        }
    }
}
