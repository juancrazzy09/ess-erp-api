namespace API.Uitilities.DTOs
{
    
    public partial class OnlineStudentAppDtos
    {
        public int? PendingCount { get; set; }
        public int? OngoingCount { get; set; }
        public int? EnrolledCount { get; set; }
        public int? TotalCount { get; set; }
    }
    public class DocumentSubmittedDtos
    {
        public long FileId { get; set; }
        public long UserId { get; set; }
        public long UploadedById { get; set; }
        public string? DocumentType { get; set; }
        public string? OriginalFileName { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? Remarks { get; set; }
        public string? ActiveStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
    public class GPADtos
    {
        public long SubjectId { get; set; }
        public long StudentId { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
        public string? Grade { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ActiveStatus { get; set; }
        public long? EncodedBy { get; set; }
    }
}
