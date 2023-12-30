using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainWell___BACKEND.Dtos.Users;
using TrainWell___BACKEND.Models.Users;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService,
            IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
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
            var jwtToken = _authService.GenerateToken(user);

            HttpContext.Response.Headers.Add("Authorization", "Bearer " + jwtToken);
            return Ok(new { token = jwtToken });
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult> RefreshToken()
        {
            var y = _httpContextAccessor.HttpContext.Items;

            var user = await _userService.GetCurrentUser();

            if (user == null)
            {
                return Unauthorized();
            }

            var newToken = _authService.RefreshToken(user);

            HttpContext.Response.Headers.Add("Authorization", "Bearer " + newToken);

            return Ok(new { token = newToken });
        }
    }
}