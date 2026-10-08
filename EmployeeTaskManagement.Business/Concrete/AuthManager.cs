using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Core.Entities.Concrete;
using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Core.Utilities.Results.Concrete.DataResult;
using EmployeeTaskManagement.Core.Utilities.Security.Hashing;
using EmployeeTaskManagement.Core.Utilities.Security.Jwt;
using EmployeeTaskManagement.DataAccess.Abstract;
using EmployeeTaskManagement.Entities.Dtos.UserDtos;
using FluentValidation;
using AutoMapper;

namespace EmployeeTaskManagement.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly HashingHelper _hashingHelper;
        private readonly IMapper _mapper;
        private readonly IValidator<UserRegisterDto> _registerValidator;
        private readonly IValidator<UserLoginDto> _loginValidator;
        public AuthManager
        (
            IUserRepository userRepository,
            ITokenHelper tokenHelper,
            HashingHelper hashingHelper,
            IMapper mapper,
            IValidator<UserRegisterDto> registerValidator,
            IValidator<UserLoginDto> loginValidator
        )
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _hashingHelper = hashingHelper;
            _mapper = mapper;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
        }

        public async Task<IDataResult<UserDto>> Register(UserRegisterDto userRegisterDto, CancellationToken cancellationToken){
            var validationResult = await _registerValidator.ValidateAsync(userRegisterDto, cancellationToken);
            if (!validationResult.IsValid){
                return new ErrorDataResult<UserDto>(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var existingUser = await _userRepository.Get(u => u.Username == userRegisterDto.Username, cancellationToken);
            if (existingUser is not null){
                return new ErrorDataResult<UserDto>("This username is already taken.");
            }

            var user = _mapper.Map<User>(userRegisterDto);
            user.PasswordHash = _hashingHelper.Hash(userRegisterDto.Password);

            await _userRepository.Add(user, cancellationToken);

            return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(user));
        }
        public async Task<IDataResult<AccessTokenDto>> Login(UserLoginDto userLoginDto, CancellationToken cancellationToken){
            var validationResult = await _loginValidator.ValidateAsync(userLoginDto, cancellationToken);
            if (!validationResult.IsValid){
                return new ErrorDataResult<AccessTokenDto>(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var user = await _userRepository.Get(u => u.Username == userLoginDto.Username, cancellationToken);
            if (user is null || !_hashingHelper.Verify(user.PasswordHash, userLoginDto.Password)){
                return new ErrorDataResult<AccessTokenDto>("Username or password is incorrect.");
            }

            var accessToken = _tokenHelper.CreateToken(user);

            return new SuccessDataResult<AccessTokenDto>(_mapper.Map<AccessTokenDto>(accessToken));
        }
    }
}
