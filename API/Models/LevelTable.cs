using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LevelTable
    {
        [Key]
        public int LevelId { get; set; }
        public int? DivId { get; set; }
        public string? LevelName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
