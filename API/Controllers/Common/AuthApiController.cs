using API.Uitilities.DTOs;
using API.Uitilities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Common
{
    [ApiController]
    [Route("api/")]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthRepository _iauthRepository;
        public AuthApiController(IAuthRepository iauthRepository)
        {
            _iauthRepository = iauthRepository;
        }
        [HttpPost]
        [Route("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] UserDto userDetails)
        {
            try
            {
                var res = await _iauthRepository.CreateAccount(userDetails);
                if (res == null)
                {
                    return StatusCode(500, "User already exists.");
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
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthDto loginDto)
        {
            try
                {
                var res = await _iauthRepository.Login(loginDto);
                if (res == null) {
                    return Conflict("Wrong Email or Password.");
                }
                else
                {
                    return Ok(res);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [Authorize]
        [HttpPost]
        [Route("user-profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var userId = Convert.ToInt64(User.FindFirst("UserId").Value);
                var res = await _iauthRepository.GetUserData(userId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
