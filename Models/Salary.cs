namespace EMS.Models
{
    public class Salary
    {
        public int EmployeeId { get; set; }
        public double Basic { get; set; }
        public double MedicalAllowance { get; set; }
        public double TransportationAllowance { get; set; }
        public double PhoneBillAllowance { get; set; }
        public double OtherAllowance { get; set; }
        public double TaxDeduction { get; set; }
        public double OtherDeduction { get; set; }
    }
}