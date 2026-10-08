using EmployeeTaskManagement.Core.Entities;

namespace EmployeeTaskManagement.Entities.Dtos.UserDtos
{
    public class UserLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
