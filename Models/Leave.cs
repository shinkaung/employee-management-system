namespace EMS.Models
{
    public class Leave
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateOnly AppliedOn { get; set; }
        public string? Reason { get; set; }
    }
}