using Microsoft.AspNetCore.Mvc;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Model.DTO.Jwt;
using ProjectCars.Service.Contract;
using System.Threading.Tasks;

namespace ProjectCars.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/auth/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto userDto)
        {
            var result = await _authService.CreateUser(userDto);

            return Ok(result);
        }

        // POST api/auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            var result = await _authService.Login(userDto);

            return Ok(result);
        }
    }
}