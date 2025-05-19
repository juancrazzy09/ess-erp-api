using API.Uitilities.DTOs;
using API.Uitilities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Common
{
    [ApiController]
    [Route("api/auth/")]
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
        [HttpGet]
        [Route("get-campus-dropdown")]
        public async Task<IActionResult> GetCampusDropdown()
        {
            try
            {
                var res = await _iauthRepository.GetCampusDropdown();
                return Ok(res);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message); 
            }
        }
        [HttpGet]
        [Route("get-division-dropdown")]
        public async Task<IActionResult> GetDivisionDropdown()
        {
            try
            {
                var res = await _iauthRepository.GetDivisionDropdown();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-level-dropdown")]
        public async Task<IActionResult> GetLevelDropdown([FromQuery] int DivId = 0)
        {
            try
            {
                var res = await _iauthRepository.GetLevelDropdown(DivId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-strand-dropdown")]
        public async Task<IActionResult> GetStrandDropdown([FromQuery] int levelId = 0)
        {
            try
            {
                var res = await _iauthRepository.GetStrandDropdown(levelId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-nationality-dropdown")]
        public async Task<IActionResult> GetNationalityDropdown()
        {
            try
            {
                var res = await _iauthRepository.GetNationalityDropdown();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-religion-dropdown")]
        public async Task<IActionResult> GetReligionDropdown()
        {
            try
            {
                var res = await _iauthRepository.GetReligionDropdown();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-province-dropdown")]
        public async Task<IActionResult> GetProvinceDropdown()
        {
            try
            {
                var res = await _iauthRepository.GetProvinceDropdown();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-municipality-dropdown")]
        public async Task<IActionResult> GetMunicipalityDropdown([FromQuery] long ProvinceId = 0)
        {
            try
            {
                var res = await _iauthRepository.GetMunicipalityDropdown(ProvinceId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-barangay-dropdown")]
        public async Task<IActionResult> GetBrgyDropdown([FromQuery] long MunicipalityId = 0)
        {
            try
            {
                var res = await _iauthRepository.GetBrgyDropdown(MunicipalityId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
