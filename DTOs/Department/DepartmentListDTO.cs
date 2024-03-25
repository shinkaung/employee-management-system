namespace EMS.DTOs
{
    public class DepartmentListDTO
    {
        public int Id { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }

        /* Navigational Properties */
        public EmployeeMinimalDTO HeadOfDepartment { get; set; } = null!;
    }
}