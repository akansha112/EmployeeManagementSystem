using System.Data;

namespace EmployeeManagementSystem.Entities.Domains
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string EmployeeCode { get; set; } = default!;

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public DateTime DateOfJoining { get; set; }

        public decimal BasicSalary { get; set; }

        public bool IsActive { get; set; } = true;

        // Department relationship
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }  
        

        // Manager hierarchy
        public Guid? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        public ICollection<Employee> Subordinates { get; set; }
            = new List<Employee>();

        public ICollection<LeaveRequest> LeaveRequests { get; set; }
            = new List<LeaveRequest>();

        public ICollection<Payroll> Payrolls { get; set; }
            = new List<Payroll>();
    }

}
