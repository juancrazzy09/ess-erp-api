using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class DivisionTable
    {
        [Key]
        public int DivId { get; set; }
        public string? DivName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
