using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school.dashboard.DBContext;
using school.dashboard.Repository.IRepository;
using school.dashboard.Model;


namespace school.dashboard.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly SQLContext _dbContext;
        public RolesRepository(SQLContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Roles>> GetRoles()
        {
            try
            {
                var staffList = (IEnumerable<Roles>)_dbContext.Roles;
                if (staffList != null && staffList.Count() > 0)
                {
                    return Task.FromResult(staffList);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
