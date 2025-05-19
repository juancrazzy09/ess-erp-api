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
        public async Task<IActionResult> InsertStudentOnlineApp([FromBody] StudentDtos student)
        {
            try
            {
                var res = await _iadmissionRepository.InsertStudentOnlineApp(student);
                if (res == null)
                {
                    return StatusCode(500, "Student already exists.");
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
        [Route("get-online-application")]
        public async Task<IActionResult> GetOnlineApplicationByStudent([FromQuery] string keyword, [FromQuery] int page = 1,[FromQuery] int pageSize = 10 )
        {
            try
            {
                var res = await _iadmissionRepository.GetOnlineApplicationByStudent(keyword, page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
