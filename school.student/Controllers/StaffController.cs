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
    /// API: Staff Controller
    /// Date: 19/01/2022
    /// Name: Muhammed Shibil K
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>

    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;
        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        /// <summary>
        /// Method is to get Staff data fron dbo.Staff
        /// </summary>
        /// <param name=""></param>
        /// <returns>Staff data</returns>


        // GET: api/<StaffController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Staff = await _staffRepository.GetStaff();
                if (Staff != null && Staff.Count() > 0)
                {
                    return Ok(Staff);
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
        /// Method is to get Staff data fron dbo.Staff by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Staff data</returns>

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            try
            {
                Staff staff = await _staffRepository.GetStaffById(id);
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
        /// Method is to post Staff data in dbo.Staff
        /// </summary>
        /// <param class="Staff"></param>
        /// <returns>bool</returns>

        [HttpPost]
        public async Task<bool> Post(Staff obj)
        {
            try
            {
                var result = await _staffRepository.PostStaff(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method is to update Staff data in dbo.Staff
        /// </summary>
        /// <param class="Staff"></param>
        /// <returns>bool</returns>

        [HttpPut]
        public async Task<bool> Put(Staff obj)
        {
            try
            {
                var result = await _staffRepository.UpdateStaff(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method is to delete Staff data in dbo.Staff by id
        /// </summary>
        /// <param class="Staff"></param>
        /// <returns>bool</returns>


        [HttpPost("{id}")]
        public async Task<bool> Delete(string id)
        {
            try
            {
                var result = await _staffRepository.DeleteStaff(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
