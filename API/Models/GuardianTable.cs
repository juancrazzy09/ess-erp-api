using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class GuardianTable
    {
        [Key]
        public long GuardianId { get; set; }
        public long? StudentId { get; set; }
        public string? Fname { get; set; }
        public string? Mname { get; set; }
        public string? Lname { get; set; }
        public string? Relationship { get; set; }
        public string? Email { get; set; }
        public string? isVerified { get; set; }
        public string? HomePhoneNo { get; set; }
        public string? MobilePhoneNo { get; set; }
        public long? ProvinceId { get; set; }
        public long? MunicipalityId { get; set; }
        public long? BrgyId { get; set; }
        public string? HomeStreetAddress { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
