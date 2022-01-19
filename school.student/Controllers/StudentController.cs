using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school.dashboard.Repository.IRepository;
using school.dashboard.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace school.dashboard.Controllers
{
    /// <summary>
    /// API: Students Controller
    /// Date: 19/01/2022
    /// Name: Muhammed Shibil K
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Method is to get Students data fron dbo.Students
        /// </summary>
        /// <param name=""></param>
        /// <returns>Students data</returns>
        
        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var students = await _studentRepository.GetStudents();
                if (students != null && students.Count() > 0)
                {
                    return Ok(students);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method is to get Students data fron dbo.Students by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Student data</returns>

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            try
            {
                Student student = await _studentRepository.GetStudentById(id);
                if (student != null)
                {
                    return Ok(student);
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

        /// <summary>
        /// Method is to post Students data in dbo.Students
        /// </summary>
        /// <param class="Student"></param>
        /// <returns>bool</returns>

        [HttpPost]
        public async Task<bool> Post(Student obj)
        {
            try
            {
                var result = await _studentRepository.PostStudents(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method is to update Students data in dbo.Students
        /// </summary>
        /// <param class="Student"></param>
        /// <returns>bool</returns>
        
        [HttpPut]
        public async Task<bool> Put(Student obj)
        {
            try
            {
                var result = await _studentRepository.UpdateStudents(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method is to delete Student data in dbo.Students by id
        /// </summary>
        /// <param class="Student"></param>
        /// <returns>bool</returns>
        
        [HttpPost("{id}")]
        public async Task<bool> Delete(string id)
        {
            try
            {
                var result = await _studentRepository.DeleteStudent(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
