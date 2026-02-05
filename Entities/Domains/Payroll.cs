namespace EmployeeManagementSystem.Entities.Domains
{
    public class Payroll
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;

        public decimal Basic { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }

        public decimal NetSalary => Basic + Allowances - Deductions;

        public DateTime SalaryMonth { get; set; }
    }
}
