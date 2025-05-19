using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ReligionTable
    {
        [Key]
        public long ReligionId { get; set; }
        public string? ReligionName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
