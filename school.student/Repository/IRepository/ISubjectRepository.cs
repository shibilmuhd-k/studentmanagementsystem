using school.dashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school.dashboard.Repository.IRepository
{
   public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubjectById(string id);
        Task<bool> PostSubject(Subject obj);
        Task<bool> UpdateSubject(Subject obj);
        Task<bool> DeleteSubject(string id);
    }
}
