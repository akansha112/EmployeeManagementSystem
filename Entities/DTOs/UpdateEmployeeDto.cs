namespace EmployeeManagementSystem.Entities.DTOs
{
    public class UpdateEmployeeDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public decimal BasicSalary { get; set; }

        public bool IsActive { get; set; }

        public Guid DepartmentId { get; set; }      
        public Guid? ManagerId { get; set; }
    }
}
