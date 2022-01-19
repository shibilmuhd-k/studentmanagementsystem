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
    public class StudentRepository : IStudentRepository
    {
        private readonly SQLContext _dbContext;
        public StudentRepository(SQLContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                var studentList = (IEnumerable<Student>) _dbContext.Students;
                if(studentList != null && studentList.Count() > 0)
                {
                    return Task.FromResult(studentList);
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
        public Task<Student> GetStudentById(string regID)
        {
            try
            {
                Student result = new Student();
                Student studentObj = _dbContext.Students.Where(students => students.regID == regID).FirstOrDefault();
                if (studentObj != null)
                {
                    return Task.FromResult(studentObj);
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

        public Task<bool> PostStudents(Student obj)
        {
            bool result = false;
            try
            {
                obj.Id = Guid.NewGuid().ToString();
                _dbContext.Students.Add(obj);
                var result1 = _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(result);
        }

        public Task<bool> UpdateStudents(Student obj)
        {
            bool result = false;
            try
            {
                Student studentObj = _dbContext.Students.Where(students => students.regID == obj.regID).FirstOrDefault();
                if(studentObj != null)
                {
                    if(obj.regID == studentObj.regID && studentObj.regID != null)
                    {
                        studentObj.Id= obj.Id;
                        studentObj.firstName = obj.firstName;
                        studentObj.lastName = obj.lastName;
                        studentObj.phoneNumber = obj.phoneNumber;
                        studentObj.roleId = obj.roleId;
                        studentObj.regID = obj.regID;
                        studentObj.address = obj.address;
                        studentObj.std = obj.std;
                        studentObj.sec = obj.sec;
                        studentObj.image = obj.image;

                        _dbContext.Students.Update(studentObj);
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

        public Task<bool> DeleteStudent(string regID)
        {
            bool result = false;
            try
            {
                var obj = _dbContext.Students.Where(students => students.regID == regID).FirstOrDefault();
                if (obj != null)
                {
                    _dbContext.Students.Remove(obj);
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
