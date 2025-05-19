using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class StrandTable
    {
        [Key]
        public int StrandId { get; set; }
        public int LevelId { get; set; }
        public string? StrandName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
