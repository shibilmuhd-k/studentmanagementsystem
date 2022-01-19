using school.dashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school.dashboard.Repository.IRepository
{
   public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetStaff();
        Task<Staff> GetStaffById(string id);
        Task<bool> PostStaff(Staff obj);
        Task<bool> UpdateStaff(Staff obj);
        Task<bool> DeleteStaff(string id);
    }
}
