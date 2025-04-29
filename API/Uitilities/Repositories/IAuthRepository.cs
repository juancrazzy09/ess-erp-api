using API.Uitilities.DTOs;

namespace API.Uitilities.Repositories
{
    public interface IAuthRepository
    {
        Task<UserDto?> Login(AuthDto loginInfo);
        Task<UserDto?> CreateAccount(UserDto userDetails);
        Task<UserDtoJwt?> GetUserData(long userId);
    }
}
