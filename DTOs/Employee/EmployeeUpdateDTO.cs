namespace EMS.DTOs
{
    public class EmployeeUpdateDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly JoinedDate { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}