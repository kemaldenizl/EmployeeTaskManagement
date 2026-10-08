using EmployeeTaskManagement.Core.Entities;

namespace EmployeeTaskManagement.Entities.Dtos.UserDtos
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
