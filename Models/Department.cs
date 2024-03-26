using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? DepartmentCode { get; set; }
        [Required]
        public string? DepartmentName { get; set; }

        /* Navigational Properties */
        public virtual ICollection<Unit> Units { get; set; } = [];
    }
}