using EmployeeTaskManagement.Core.Entities;

namespace EmployeeTaskManagement.Entities.Concrete
{
    public class TaskItemCreateDto : IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int EmployeeId { get; set; }
    }
}