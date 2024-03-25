namespace EMS.DTOs
{
    public class UnitDetailedDTO
    {
        public int Id { get; set; }
        public string? UnitName { get; set; }
        public string? Description { get; set; }

        /* Navigational Properties */
        public DepartmentDetailedDTO Department { get; set; } = null!;
    }
}