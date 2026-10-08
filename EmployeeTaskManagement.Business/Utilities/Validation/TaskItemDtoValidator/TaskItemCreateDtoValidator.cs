using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;
using FluentValidation;

namespace EmployeeTaskManagement.Business.Utilities.Validation.TaskItemDtoValidator
{
    public class TaskItemCreateDtoValidator : AbstractValidator<TaskItemCreateDto>
    {
        public TaskItemCreateDtoValidator()
        {
            RuleFor(t => t.Title).NotEmpty();
        }
    }
}