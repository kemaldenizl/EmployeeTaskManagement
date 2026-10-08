using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;
using FluentValidation;

namespace EmployeeTaskManagement.Business.Utilities.Validation.EmployeeDtoValidator
{
    public class EmployeeUpdateDtoValidator : AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateDtoValidator()
        {
            RuleFor(e => e.Email).EmailAddress();
        }
    }
}