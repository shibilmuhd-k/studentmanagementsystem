using school.dashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school.dashboard.Repository.IRepository
{
    public interface IRolesRepository
    {
        Task<IEnumerable<Roles>> GetRoles();
    }
}
