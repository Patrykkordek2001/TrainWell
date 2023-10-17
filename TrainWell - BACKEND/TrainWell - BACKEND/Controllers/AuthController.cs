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
            var newUser = await _authService.RegisterUser(user);
            if (newUser == null) return BadRequest("Taka nazwa użytkownika jest już zajęta");
            return Ok(new { message = "User registered" });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDto userDTO)
        {

            var user = await _authService.AuthenticateUser(userDTO);
            if (user == null) return Unauthorized("Błędna nazwa użytkownika lub login");
            var jwtToken = _authService.GenerateToken();

            return Ok(new { token = jwtToken, user = user });
                            
        }
        

    }
}
