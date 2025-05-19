using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class StudentAppFilesTable
    {
        [Key]
        public long FileId { get; set; }
        public long? StudentId { get; set; }
        public string? StudentPic2x2 { get; set; }
        public string? StudentBirthCert { get; set; }
        public string? StudentBaptismal { get; set; }
        public string? GoodMoral { get; set; }
        public string? CurrentReportCard { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; } 
    }
}
