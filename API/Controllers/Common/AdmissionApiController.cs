using API.Uitilities.DTOs;
using API.Uitilities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace API.Controllers.Common
{
    [ApiController]
    [Route("api/admission/")]
    public class AdmissionApiController : Controller
    {
        private readonly IAdmissionRepository _iadmissionRepository;
        public AdmissionApiController(IAdmissionRepository iadmissionRepository)
        {
            _iadmissionRepository = iadmissionRepository;
        }
        [HttpPost]
        [Route("student-online-application")]
        public async Task<IActionResult> InsertStudentOnlineApp([FromForm] StudentDtos student )
        {
            try
            {
                var res = await _iadmissionRepository.InsertStudentOnlineApp(student);
                if (res == null)
                {
                    return Ok(new { success = false, message = "Student already exists." });
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [Authorize]
        [HttpPost]
        [Route("get-online-application-count")]
        public async Task<IActionResult> GetOnlineApplicationByStudentCount()
        {
            try
            {
                var data = await _iadmissionRepository.GetOnlineApplicationByStudentCount();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("generate-application-table")]
        public async Task<IActionResult> GenerateApplicationTable([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = "", [FromQuery] string status = "")
        {
            try
            {
                var res = await _iadmissionRepository.GenerateApplicationTable(page, pageSize, search, status);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("get-student-id")]
        public async Task<IActionResult> GetStudentById([FromQuery] long StudentId = 0)
        {
            try
            {
                var res = await _iadmissionRepository.GetStudentById(StudentId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("insert-admission-gpa")]
        public async Task<IActionResult> InsertGpaOfStudent([FromBody] List<GPADtos> reqList)
        {
            try
            {
                var res = await _iadmissionRepository.InsertGpaOfStudent(reqList);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [Authorize]
        [HttpPost]
        [Route("get-student-gpa")]
        public async Task<IActionResult> GetStudentGpaById([FromQuery] long StudentId = 0)
        {
            try
            {
                var res = await _iadmissionRepository.GetStudentGpaById(StudentId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [Authorize]
        [HttpPost]
        [Route("get-student-docs-id")]
        public async Task<IActionResult> GetStudentDocsById([FromQuery] long StudentId = 0)
        {
            try
            {
                var res = await _iadmissionRepository.GetStudentDocsById(StudentId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
