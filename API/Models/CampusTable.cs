using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CampusTable
    {
        [Key]
        public int CampusId { get;set; }
        public string? CampusName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
