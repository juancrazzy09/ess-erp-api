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
        private readonly DBContext db;
        private readonly IConfiguration configuration;
        public AuthRepository(DBContext _db, IConfiguration configuration  )
        {
            this.db = _db;
            this.configuration = configuration;
        }
        public async Task<UserDto?> CreateAccount(UserDto userDetails)
        {
            try
            {
                var userExist = db.UsersTable.Any(x => x.Email == userDetails.Email);
                if (userExist)
                {
                    return null;
                }
                else
                {
                    UserTable user = new UserTable
                    {
                        Fname = userDetails.Fname,
                        Mname = userDetails.Mname,
                        Lname = userDetails.Lname,
                        Email = userDetails.Email,
                        Password = BCrypt.Net.BCrypt.HashPassword(userDetails.Password),
                        ActiveStatus = "P", 
                        DateCreated = DateTime.Now
                    };
                    db.UsersTable.Add(user);
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
                var user = await db.UsersTable
                    .Where(u => u.Email == loginDto.Email)
                    .Select(u => new UserDto
                    {
                        UserId = u.UserId,
                        Fname = u.Fname,
                        Mname = u.Mname,
                        Lname = u.Lname,
                        Email = u.Email,
                        Password = u.Password,
                        ActiveStatus = u.ActiveStatus
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
                var user = await db.UsersTable
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
    }
}
