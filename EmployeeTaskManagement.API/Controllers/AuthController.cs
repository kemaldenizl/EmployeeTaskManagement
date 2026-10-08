using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService){
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto, CancellationToken cancellationToken)
        {
            var result = await _authService.Register(dto, cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto, CancellationToken cancellationToken)
        {
            var result = await _authService.Login(dto, cancellationToken);
            return result.Success ? Ok(result) : Unauthorized(result);
        }
    }
}
