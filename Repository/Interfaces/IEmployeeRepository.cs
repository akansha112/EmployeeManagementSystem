using EmployeeManagementSystem.Entities.DTOs;

namespace EmployeeManagementSystem.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeListDto>> GetAllAsync();
        Task<List<EmployeeDto>> GetFilteredAsync(EmployeeQueryDto query);

        Task<EmployeeDto?> GetByIdAsync(Guid id);

        Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto);

        Task<EmployeeDto?> UpdateAsync(Guid id, UpdateEmployeeDto dto);

        Task<bool> DeleteAsync(Guid id);
    }
}
