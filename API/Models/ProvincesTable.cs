using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ProvincesTable
    {
        [Key]
        public long ProvinceId { get; set; }
        public string? ProvinceName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
