using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school.dashboard.Repository.IRepository;
using school.dashboard.Model;

namespace school.dashboard.Controllers
{
    /// <summary>
    /// API: Subject Controller
    /// Date: 19/01/2022
    /// Name: Muhammed Shibil K
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        /// <summary>
        /// Method is to get Subject data fron dbo.Subject
        /// </summary>
        /// <param name=""></param>
        /// <returns>Subject data</returns>

        // GET: api/<SubjectController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Subject = await _subjectRepository.GetSubjects();
                if (Subject != null && Subject.Count() > 0)
                {
                    return Ok(Subject);
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
        /// Method is to get Subject data fron dbo.Subject by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Subject data</returns>

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            try
            {
                Subject staff = await _subjectRepository.GetSubjectById(id);
                if (staff != null)
                {
                    return Ok(staff);
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
        /// Method is to post Subject data in dbo.Students
        /// </summary>
        /// <param class="Subject"></param>
        /// <returns>bool</returns>

        [HttpPost]
        public async Task<bool> Post(Subject obj)
        {
            try
            {
                var result = await _subjectRepository.PostSubject(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method is to update Subject data in dbo.Subject
        /// </summary>
        /// <param class="Subject"></param>
        /// <returns>bool</returns>

        [HttpPut]
        public async Task<bool> Put(Subject obj)
        {
            try
            {
                var result = await _subjectRepository.UpdateSubject(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method is to delete Subject data in dbo.Subject by id
        /// </summary>
        /// <param class="Subject"></param>
        /// <returns>bool</returns>

        [HttpPost("{id}")]
        public async Task<bool> Delete(string id)
        {
            try
            {
                var result = await _subjectRepository.DeleteSubject(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
