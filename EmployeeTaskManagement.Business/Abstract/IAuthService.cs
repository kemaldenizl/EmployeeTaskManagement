using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Entities.Dtos.UserDtos;

namespace EmployeeTaskManagement.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<UserDto>> Register(UserRegisterDto userRegisterDto, CancellationToken cancellationToken);
        Task<IDataResult<AccessTokenDto>> Login(UserLoginDto userLoginDto, CancellationToken cancellationToken);
    }
}
