using EmployeeTaskManagement.Core.Entities;

namespace EmployeeTaskManagement.Entities.Concrete
{
    public class TaskItemDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int EmployeeId { get; set; }
    }
}