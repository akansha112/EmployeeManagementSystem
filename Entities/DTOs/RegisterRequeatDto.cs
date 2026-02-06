using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Entities.DTOs
{
    public class RegisterRequeatDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string userName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
