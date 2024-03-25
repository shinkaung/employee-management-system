namespace EMS.DTOs
{
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        /* Navigational Properties */
        public int EmployeeId { get; set; }
    }
}