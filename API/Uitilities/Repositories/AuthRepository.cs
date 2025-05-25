using API.Models;
using API.Uitilities.DTOs;
using API.Uitilities.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Uitilities.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EssErpDbContext db;
        private readonly IConfiguration configuration;
        public AuthRepository(EssErpDbContext _db, IConfiguration configuration  )
        {
            this.db = _db;
            this.configuration = configuration;
        }
        public async Task<UserDto?> CreateAccount(UserDto userDetails)
        {
            try
            {
                var userExist = db.UsersTables.Any(x => x.Email == userDetails.Email);
                if (userExist)
                {
                    return null;
                }
                else
                {
                    //Insert User info for UserTable
                    UsersTable user = new UsersTable
                    {
                        Fname = userDetails.Fname,
                        Mname = userDetails.Mname,
                        Lname = userDetails.Lname,
                        Email = userDetails.Email,
                        Password = BCrypt.Net.BCrypt.HashPassword(userDetails.Password),
                        ActiveStatus = "Y", 
                        DateCreated = DateTime.Now,
                        UserRole = userDetails.UserRole,
                        SpecialRole = userDetails.SpecialRole,
                    };
                    db.UsersTables.Add(user);
                    await db.SaveChangesAsync();
                    userDetails.UserId = user.UserId;
                    return userDetails;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while creating the user: " + ex.Message);
            }
        }
        public async Task<UserDto?> Login(AuthDto loginDto)
        {
            try
            {
                var user = await db.UsersTables
                    .Where(u => u.Email == loginDto.Email)
                    .Select(u => new UserDto
                    {
                        UserId = u.UserId,
                        Fname = u.Fname,
                        Mname = u.Mname,
                        Lname = u.Lname,
                        Email = u.Email,
                        Password = u.Password,
                        ActiveStatus = u.ActiveStatus,
                        UserRole = u.UserRole,
                        SpecialRole = u.SpecialRole
                    })
                    .FirstOrDefaultAsync();
                bool verified = false;
                if (user != null)
                {
                    verified = BCrypt.Net.BCrypt.Verify(loginDto.Password.Trim(), user.Password);
                    if (verified)
                    {
                        // User Claims
                        var claims = new List<Claim>
                        {
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("Email", user.Email.ToString()),
                        new Claim("Fname", user.Fname.ToString()),
                        new Claim("Mname", user.Mname.ToString()),
                        new Claim("Lname", user.Lname.ToString()),
                        new Claim("ActiveStatus", user.ActiveStatus.ToString()),
                        new Claim("UserRole" , user.UserRole.ToString()),
                        new Claim("SpecialRole", user.SpecialRole.ToString())
                        };
                        // Encrypt credentials
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var auth = new JwtSecurityToken(configuration["Jwt:Issuer"],
                            configuration["Jwt:Issuer"],
                            claims,
                            expires: DateTime.Now.AddHours(5), // Set to 5 mins
                            signingCredentials: credentials);

                        // Generate JWT 
                        var token = new JwtSecurityTokenHandler().WriteToken(auth);
                        user.Token = token;
                        return user;
                    }
                }
                return null;
               
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the user: " + ex.Message);
            }
        }
        public async Task<UserDtoJwt?> GetUserData(long userId)
        {
            try
            {
                var user = await db.UsersTables
                    .Where(u => u.UserId == userId)
                    .Select(u => new UserDtoJwt
                    {
                        UserId = u.UserId,  
                        Fname = u.Fname,
                        Mname = u.Mname,
                        Lname = u.Lname,
                        Email = u.Email,
                        ActiveStatus = u.ActiveStatus
                    })
                    .FirstOrDefaultAsync();
                Console.WriteLine(user != null ? "User found!" : "User not found.");
                return user;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the user: " + ex.Message);
            }
        }
        public async Task<IEnumerable<CampusDto>> GetCampusDropdown()
        {
            try
            {
                var query = await db.CampusTables.Select( c => new CampusDto
                {
                    CampusId = c.CampusId,
                    CampusName = c.CampusName,
                    DateCreated = c.DateCreated,

                }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<DivisionDto>> GetDivisionDropdown()
        {
            try
            {
                var query = await db.DivisionTables.Select(c => new DivisionDto
                {
                    DivId = c.DivId,
                    DivName = c.DivName,
                    DateCreated = c.DateCreated,

                }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<LevelDto>> GetLevelDropdown(int DivId = 0)
        {
            try
            {
                var query = await db.LevelTables
                    .Where(l => l.DivId == DivId)
                    .Select(l => new LevelDto
                    {
                        LevelId = l.LevelId,
                        DivId = l.DivId,
                        LevelName = l.LevelName,
                        DateCreated = l.DateCreated,

                    }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<StrandDto>> GetStrandDropdown(int levelId = 0)
        {
            try
            {
                var query = await db.StrandTables
                    .Where(s => s.LevelId == levelId)
                    .Select(s => new StrandDto
                    {
                        StrandId = s.StrandId,
                        LevelId = s.LevelId,
                        StrandName = s.StrandName,
                        DateCreated= s.DateCreated,

                    }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<NationalityDto>> GetNationalityDropdown()
        {
            try
            {
                var query = await db.NationalityTables.Select(n => new NationalityDto
                {
                    NationalityId = n.NationalityId,
                    NationalityName = n.NationalityName,
                    DateCreated = n.DateCreated,

                }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ReligionDto>> GetReligionDropdown()
        {
            try
            {
                var query = await db.ReligionTables
                    .Where(n => n.ActiveStatus == "Y")
                    .Select(n => new ReligionDto
                    {
                        ReligionId = n.ReligionId,
                        ReligionName = n.ReligionName,
                        DateCreated = n.DateCreated,

                    }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProvinceDto>> GetProvinceDropdown()
        {
            try
            {
                var query = await db.ProvincesTables.Select(n => new ProvinceDto
                {
                    ProvinceId = n.ProvinceId,
                    ProvinceName = n.ProvinceName,
                    DateCreated = n.DateCreated,

                }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<MunicipalityDto>> GetMunicipalityDropdown(long ProvinceId = 0)
        {
            try
            {
                var query = await db.MunicipalityTables
                    .Where(n => n.ProvinceId == ProvinceId) 
                    .Select(n => new MunicipalityDto
                    {
                        MunicipalityId = n.MunicipalityId,
                        ProvinceId = n.ProvinceId,
                        MunicipalityName = n.MunicipalityName,
                        DateCreated = n.DateCreated,

                    }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<BrgyDto>> GetBrgyDropdown(long MunicipalityId = 0)
        {
            try
            {
                var query = await db.BarangayTables
                    .Where(n => n.MunicipalityId == MunicipalityId) 
                    .Select(n => new BrgyDto
                    {
                        BrgyId = n.BrgyId,
                        MunicipalityId = n.MunicipalityId,
                        BrgyName = n.BrgyName,
                        DateCreated = n.DateCreated,

                    }).ToListAsync();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
