using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.Entities;

namespace EmployeeTaskManagement.Entities.Concrete
{
    public class TaskItem : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}