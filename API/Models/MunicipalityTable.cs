using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class MunicipalityTable
    {
        [Key]
        public long MunicipalityId { get; set; }
        public long? ProvinceId { get; set; }
        public string? MunicipalityName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
