using EmployeeTaskManagement.Entities.Dtos.UserDtos;
using FluentValidation;

namespace EmployeeTaskManagement.Business.Utilities.Validation.UserDtoValidator
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(u => u.Username).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
