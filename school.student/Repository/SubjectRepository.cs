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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SQLContext _dbContext;
        public SubjectRepository(SQLContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Subject>> GetSubjects()
        {
            try
            {
                var studentList = (IEnumerable<Subject>)_dbContext.Subjects;
                if (studentList != null && studentList.Count() > 0)
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

        public Task<Subject> GetSubjectById(string subjectID)
        {
            try
            {
                Subject result = new Subject();
                Subject subObj = _dbContext.Subjects.Where(Subjects => Subjects.subId == subjectID).FirstOrDefault();
                if (subObj != null)
                {
                    return Task.FromResult(subObj);
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

        public Task<bool> PostSubject(Subject obj)
        {
            bool result = false;
            try
            {
                obj.Id = Guid.NewGuid().ToString();
                obj.subId = Guid.NewGuid().ToString();
                _dbContext.Subjects.Add(obj);
                var result1 = _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(result);
        }

        public Task<bool> UpdateSubject(Subject obj)
        {
            bool result = false;
            try
            {
                Subject subObj = _dbContext.Subjects.Where(Subject => Subject.subId == obj.subId).FirstOrDefault();
                if (subObj != null)
                {
                    if (subObj.subId != null && obj.subId == subObj.subId)
                    {
                        subObj.subId = obj.subId;
                        subObj.subject = obj.subject;
                        _dbContext.Subjects.Update(subObj);
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

        public Task<bool> DeleteSubject(string subId)
        {
            bool result = false;
            try
            {
                var obj = _dbContext.Subjects.Where(Subject => Subject.subId == subId).FirstOrDefault();
                if (obj != null)
                {
                    _dbContext.Subjects.Remove(obj);
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
