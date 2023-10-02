using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _usersService;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration, IUserService userService)
        {
            _usersService = userService;
            _configuration = configuration;
            _authService = authService;

        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register(User user)
        {
            await _authService.RegisterUser(user);
            return Ok(new { message = "User registered" });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDto userDTO)
        {

            var user = await _authService.AuthenticateUser(userDTO);
            if (user == null) return Unauthorized("Wrong login or password!");
            var jwtToken = _authService.GenerateToken();

            return Ok(new { token = jwtToken });
        }
        [HttpGet("Test")]
        public async Task<ActionResult> Test()
        {
            return Ok(new { message = "TESST" });
        }


    }
}
