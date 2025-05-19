using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class BarangayTable
    {
        [Key]
        public long BrgyId { get; set; }
        public long? MunicipalityId { get; set; }
        public string? BrgyName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
