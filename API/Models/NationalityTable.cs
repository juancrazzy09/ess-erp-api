using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class NationalityTable
    {
        [Key]
        public int NationalityId { get; set; }
        public string? NationalityName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
