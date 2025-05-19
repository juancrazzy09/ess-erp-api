using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class EducBGTable
    {
        [Key]
        public int EducBgId { get; set; }
        public string? EducBgName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
