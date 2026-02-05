using AutoMapper;
using EmployeeManagementSystem.Entities.Domains;
using EmployeeManagementSystem.Entities.DTOs;

namespace EmployeeManagementSystem.AutoMapperMappings
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            // Create DTO → Entity
            CreateMap<CreateEmployeeDto, Employee>();

            // Update DTO → Entity
            CreateMap<UpdateEmployeeDto, Employee>();

            // Entity → EmployeeDto (Read)
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department.Name))               
                .ForMember(dest => dest.ManagerName,
                    opt => opt.MapFrom(src =>
                        src.Manager != null
                            ? src.Manager.FirstName + " " + src.Manager.LastName
                            : null));

            // Entity → EmployeeListDto
            CreateMap<Employee, EmployeeListDto>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department.Name));
                
        }

    }
    }

