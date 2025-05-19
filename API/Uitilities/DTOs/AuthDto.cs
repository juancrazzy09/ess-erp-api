namespace API.Uitilities.DTOs
{
    public class AuthDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class UserDto
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string? Fname { get; set; }
        public string? Mname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? ActiveStatus { get; set; }
        public string? Token { get; set; }
    }
    public class UserDtoJwt
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string? Fname { get; set; }
        public string? Mname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? ActiveStatus { get; set; }
    }
    public class CampusDto
    {
        public int CampusId { get; set; }  
        public string? CampusName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class DivisionDto
    {
        public int DivId { get; set; }
        public string? DivName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class LevelDto
    {
        public int LevelId { get; set; }
        public int? DivId { get; set; }
        public string? LevelName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class StrandDto
    {
        public int StrandId { get; set; }
        public int LevelId { get; set; }
        public string? StrandName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class NationalityDto
    {
        public int NationalityId { get; set; }
        public string? NationalityName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class ReligionDto
    {
        public long ReligionId { get; set; }
        public string? ReligionName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class ProvinceDto
    {
        public long ProvinceId { get; set; }
        public string? ProvinceName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class MunicipalityDto
    {
        public long MunicipalityId { get; set; }
        public long? ProvinceId { get; set; }
        public string? MunicipalityName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class BrgyDto
    {
        public long BrgyId { get; set; }
        public long? MunicipalityId { get; set; }
        public string? BrgyName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
