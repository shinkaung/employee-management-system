namespace EMS.DTOs
{
    public class DepartmentUpdateDTO
    {
        public int Id { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int HeadOfDepartmentId { get; set; }
    }
}