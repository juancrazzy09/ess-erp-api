using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class StudentAppTable
    {
        [Key]
        public long AppId { get; set; }
        public long? StudentId { get; set; }
        public string? AppNumber {  get; set; }
        public string? ActiveStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
