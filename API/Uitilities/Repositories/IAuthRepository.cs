using API.Uitilities.DTOs;

namespace API.Uitilities.Repositories
{
    public interface IAuthRepository
    {
    
        Task<UserDto?> Login(AuthDto loginInfo);
        Task<UserDto?> CreateAccount(UserDto userDetails);
        Task<UserDtoJwt?> GetUserData(long userId);
        Task<IEnumerable<CampusDto>> GetCampusDropdown();
        Task<IEnumerable<DivisionDto>> GetDivisionDropdown();
        Task<IEnumerable<LevelDto>> GetLevelDropdown(int DivId = 0);
        Task<IEnumerable<StrandDto>> GetStrandDropdown(int levelId = 0);
        Task<IEnumerable<NationalityDto>> GetNationalityDropdown();
        Task<IEnumerable<ReligionDto>> GetReligionDropdown();
        Task<IEnumerable<ProvinceDto>> GetProvinceDropdown();
        Task<IEnumerable<MunicipalityDto>> GetMunicipalityDropdown(long ProvinceId = 0);
        Task<IEnumerable<BrgyDto>> GetBrgyDropdown(long BrgyId = 0);
    }
}
