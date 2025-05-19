using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class StudentDocsTable
    {
        [Key]
        public long DocsId { get; set; }
        public long? StudentId { get; set; }
        public string? TwoByTwoPhoto { get; set; }
        public DateTime? TwoByTwoPhotoSubmitted { get; set; }
        public string? GoodMoral { get; set; }
        public DateTime? GoodMoralSubmitted { get; set; }
        public string? LatestReportCard { get; set; }
        public DateTime? LatestReportCardSubmitted { get; set; }
        public string? ECD { get; set; }
        public DateTime? ECDSubmitted { get; set; }
        public string? GradeTenCert { get; set; }
        public DateTime? GradeTenCertSubmitted { get; set; }
        public string? Form137 { get; set; }
        public DateTime? Form137Submitted { get; set; }
        public string? GradeNineRepCard { get; set; }
        public DateTime? GradeNineRepCardSubmitted { get; set; }
        public string? SSP { get; set; }
        public DateTime? SSPSubmitted { get; set; }
        public string? PassPort { get; set; }
        public DateTime? PassPortSubmitted { get; set; }
        public string? NCAE { get; set; }
        public DateTime? NCAESubmitted { get; set; }
        public string? PSA { get; set;}
        public DateTime? PSASubmitted { get; set; }
        public string? QVACert { get; set; }
        public DateTime? QVACertSubmitted { get; set; }
        public string? QVR { get; set; }
        public DateTime? QVRSubmitted { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
