using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;
using FluentValidation;

namespace EmployeeTaskManagement.Business.Utilities.Validation.TaskItemDtoValidator
{
    public class TaskItemUpdateDtoValidator : AbstractValidator<TaskItemUpdateDto>
    {
        public TaskItemUpdateDtoValidator()
        {
            RuleFor(t => t.Title).NotEmpty();
        }
    }
}