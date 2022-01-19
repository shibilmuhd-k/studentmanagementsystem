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
    public class StaffRepository : IStaffRepository
    {
        private readonly SQLContext _dbContext;
        public StaffRepository(SQLContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Staff>> GetStaff()
        {
            try
            {
                var staffList = (IEnumerable<Staff>)_dbContext.Staff;
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

        public Task<Staff> GetStaffById(string staffID)
        {
            try
            {
                Staff result = new Staff();
                Staff staffObj = _dbContext.Staff.Where(Staff => Staff.staffID == staffID).FirstOrDefault();
                if (staffObj != null)
                {
                    return Task.FromResult(staffObj);
                }
                else
                {
                    return Task.FromResult(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> PostStaff(Staff obj)
        {
            bool result = false;
            try
            {
                obj.Id = Guid.NewGuid().ToString();
                _dbContext.Staff.Add(obj);
                var result1 = _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(result);
        }

        public Task<bool> UpdateStaff(Staff obj)
        {
            bool result = false;
            try
            {
                Staff staffObj = _dbContext.Staff.Where(Staff => Staff.staffID == obj.staffID).FirstOrDefault();
                if (staffObj != null)
                {
                    if (staffObj.staffID != null && obj.staffID == staffObj.staffID && obj.Id == staffObj.Id)
                    {
                        staffObj.Id = obj.Id;
                        staffObj.firstName = obj.firstName;
                        staffObj.lastName = obj.lastName;
                        staffObj.phoneNumber = obj.phoneNumber;
                        staffObj.roleId = obj.roleId;
                        staffObj.staffID = obj.staffID;
                        staffObj.address = obj.address;
                        staffObj.image = obj.image;
                        staffObj.email = obj.email;

                        _dbContext.Staff.Update(staffObj);
                        result = Convert.ToBoolean(_dbContext.SaveChanges());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(result);
        }

        public Task<bool> DeleteStaff(string staffID)
        {
            bool result = false;
            try
            {
                var obj = _dbContext.Staff.Where(Staff => Staff.staffID == staffID).FirstOrDefault();
                if (obj != null)
                {
                    _dbContext.Staff.Remove(obj);
                    result = Convert.ToBoolean(_dbContext.SaveChanges());
                }
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
