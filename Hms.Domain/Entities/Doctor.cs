using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hms.Domain.Entities
{

    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        public int DocId { get; set; }
        public string? DocName { get; set; }
        public string? DocPhone { get; set; }
        public string? DocSpecialization { get; set; }
    }
}
