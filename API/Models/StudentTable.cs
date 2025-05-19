using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class StudentTable
    {
        [Key]
        public long StudentId { get; set; }
        public string? StudentNumber { get; set; }
        public string? Fname { get; set; }
        public string? Mname { get; set; }
        public string? Lname { get; set; }
        public int? CampusId { get; set; }
        public int? LevelId { get; set; }
        public int? DivId { get; set; }
        public int? StrandId { get; set; }
        public string? StudentType { get; set; }
        public int? NationalityId { get; set; }
        public long? ReligionId { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? ActiveStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
