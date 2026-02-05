using AutoMapper;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Entities.Domains;
using EmployeeManagementSystem.Entities.DTOs;
using EmployeeManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeListDto>> GetAllAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)                
                .Include(e => e.Manager)
                .ToListAsync();

            return _mapper.Map<List<EmployeeListDto>>(employees);
        }

        public async Task<EmployeeDto?> GetByIdAsync(Guid id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)               
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(e => e.Id == id);

            return employee == null
                ? null
                : _mapper.Map<EmployeeDto>(employee);
        }
        public async Task<List<EmployeeDto>> GetFilteredAsync(EmployeeQueryDto query)
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .AsQueryable();

            //  Filter by name
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                employees = employees.Where(e =>
                    e.FirstName.Contains(query.Name) ||
                    e.LastName.Contains(query.Name));
            }

            // Filter by department
            if (query.DepartmentId.HasValue)
            {
                employees = employees.Where(e =>
                    e.DepartmentId == query.DepartmentId.Value);
            }

            // Filter by active
            if (query.IsActive.HasValue)
            {
                employees = employees.Where(e =>
                    e.IsActive == query.IsActive.Value);
            }

            //  Sorting
            employees = query.SortBy?.ToLower() switch
            {
                "salary" => query.IsDescending
                    ? employees.OrderByDescending(e => e.BasicSalary)
                    : employees.OrderBy(e => e.BasicSalary),

                _ => query.IsDescending
                    ? employees.OrderByDescending(e => e.FirstName)
                    : employees.OrderBy(e => e.FirstName)
            };

            var result = await employees.ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(result);
        }


        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            // reload with includes
            var created = await GetByIdAsync(employee.Id);
            return created!;
        }

        public async Task<EmployeeDto?> UpdateAsync(Guid id, UpdateEmployeeDto dto)
        {
            var existing = await _context.Employees.FindAsync(id);

            if (existing == null)
                return null;

            _mapper.Map(dto, existing);

            await _context.SaveChangesAsync();

            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


