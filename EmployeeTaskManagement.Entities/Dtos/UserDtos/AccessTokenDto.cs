using EmployeeTaskManagement.Core.Entities;

namespace EmployeeTaskManagement.Entities.Dtos.UserDtos
{
    public class AccessTokenDto : IDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
