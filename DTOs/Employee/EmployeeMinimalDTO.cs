using EMS.Models;

namespace EMS.DTOs
{
    public class EmployeeMinimalDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}