using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school.dashboard.Model;

namespace school.dashboard.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(string id);
        Task<bool> PostStudents(Student obj);
        Task<bool> UpdateStudents(Student obj);
        Task<bool> DeleteStudent(string id);



    }
}
