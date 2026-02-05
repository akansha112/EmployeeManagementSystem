namespace EmployeeManagementSystem.Entities.DTOs
{
    public class EmployeeQueryDto
    {
        public string? Name { get; set; }
        public Guid? DepartmentId { get; set; }
        public bool? IsActive { get; set; }

        public string? SortBy { get; set; } = "name"; // name | salary
        public bool IsDescending { get; set; } = false;
    }
}
