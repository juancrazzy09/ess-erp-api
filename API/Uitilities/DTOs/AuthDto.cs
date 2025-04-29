namespace API.Uitilities.DTOs
{
    public class AuthDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class UserDto
    {
        public long UserId { get; set; }
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
        public long UserId { get; set; }
        public string? Fname { get; set; }
        public string? Mname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
