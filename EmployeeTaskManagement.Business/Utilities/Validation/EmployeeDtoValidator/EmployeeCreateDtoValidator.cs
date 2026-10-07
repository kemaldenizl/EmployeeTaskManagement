using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;
using FluentValidation;

namespace EmployeeTaskManagement.Business.Utilities.Validation.EmployeeDtoValidator
{
    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(e => e.Email).EmailAddress();
                
        }
    }
}