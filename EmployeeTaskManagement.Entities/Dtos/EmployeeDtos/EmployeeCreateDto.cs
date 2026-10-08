using EmployeeTaskManagement.Core.Entities;

namespace EmployeeTaskManagement.Entities.Dtos.EmployeeDtos
{
    public class EmployeeCreateDto : IDto {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}