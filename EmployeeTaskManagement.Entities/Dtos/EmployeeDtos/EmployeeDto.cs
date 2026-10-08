using EmployeeTaskManagement.Core.Entities;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;

namespace EmployeeTaskManagement.Entities.Dtos.EmployeeDtos
{
    public class EmployeeDto : IDto {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<TaskItemDto> Tasks { get; set; } = new();
    }
}