using AutoMapper;
using EmployeeTaskManagement.Entities.Concrete;
using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;

namespace EmployeeTaskManagement.Business.Utilities.Mapping
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile(){
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeCreateDto, Employee>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.Tasks, o => o.Ignore());
            

            CreateMap<EmployeeUpdateDto, Employee>()
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.Tasks, o => o.Ignore());
        }
    }
}