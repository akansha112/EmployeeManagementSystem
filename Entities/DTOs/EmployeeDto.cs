namespace EmployeeManagementSystem.Entities.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string EmployeeCode { get; set; } = default!;

        public string FullName { get; set; } = default!;

        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public DateTime DateOfJoining { get; set; }

        public decimal BasicSalary { get; set; }

        public bool IsActive { get; set; }

        public string DepartmentName { get; set; } = default!;
       
        public string? ManagerName { get; set; }
    }
}
