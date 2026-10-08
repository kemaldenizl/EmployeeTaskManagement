using AutoMapper;
using EmployeeTaskManagement.Entities.Concrete;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;

namespace EmployeeTaskManagement.Business.Utilities.Mapping
{
    public class TaskItemProfile: Profile
    {
        public TaskItemProfile(){
            CreateMap<TaskItem, TaskItemDto>();

            CreateMap<TaskItemCreateDto, TaskItem>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.Employee, o => o.Ignore());
            

            CreateMap<TaskItemUpdateDto, TaskItem>()
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.Employee, o => o.Ignore());
        }
    }
}