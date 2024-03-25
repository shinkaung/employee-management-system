using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamId { get; set; }
        [Required]
        public string? TeamName { get; set; }
        public string? Description { get; set; }

        /* Navigational Properties */
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}