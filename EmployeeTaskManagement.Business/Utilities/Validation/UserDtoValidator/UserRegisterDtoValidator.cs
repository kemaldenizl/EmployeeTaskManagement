using EmployeeTaskManagement.Entities.Dtos.UserDtos;
using FluentValidation;

namespace EmployeeTaskManagement.Business.Utilities.Validation.UserDtoValidator
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(u => u.Username).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(u => u.Password).NotEmpty().MinimumLength(6);
        }
    }
}
