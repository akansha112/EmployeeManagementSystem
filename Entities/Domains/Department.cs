namespace EmployeeManagementSystem.Entities.Domains
{
    public class Department
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}
