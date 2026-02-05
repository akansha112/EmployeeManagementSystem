namespace EmployeeManagementSystem.Entities.DTOs
{
    public class EmployeeListDto
    {
        public Guid Id { get; set; }

        public string EmployeeCode { get; set; } = default!;
        public string FullName { get; set; } = default!;

        public string DepartmentName { get; set; } = default!;     

        public bool IsActive { get; set; }
    }
}
