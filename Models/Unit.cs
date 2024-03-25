using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UnitName { get; set; }
        public string? Description { get; set; }

        /* Navigational Properties */
        [Required]
        [ForeignKey("id")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; } = [];
    }
}