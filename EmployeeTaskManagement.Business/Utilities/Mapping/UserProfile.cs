using AutoMapper;
using EmployeeTaskManagement.Core.Entities.Concrete;
using EmployeeTaskManagement.Core.Utilities.Security.Jwt;
using EmployeeTaskManagement.Entities.Dtos.UserDtos;

namespace EmployeeTaskManagement.Business.Utilities.Mapping
{
    public class UserProfile: Profile
    {
        public UserProfile(){
            CreateMap<User, UserDto>();

            CreateMap<UserRegisterDto, User>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.PasswordHash, o => o.Ignore());

            CreateMap<AccessToken, AccessTokenDto>();
        }
    }
}
