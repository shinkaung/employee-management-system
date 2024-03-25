using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Role { get; set; }

        /* Navigational Properties */
        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}