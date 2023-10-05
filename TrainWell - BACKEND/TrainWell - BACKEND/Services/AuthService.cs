using Microsoft.AspNetCore.Mvc; 
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;
using System.Linq;
using System.Threading.Tasks;

namespace TrainWell___BACKEND.Services
{
    public class AuthService : IAuthService
    {
        private readonly ISqlRepository<User> _authRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IUserService _usersService;


        public AuthService(ISqlRepository<User> authRepository, IHttpContextAccessor httpContextAccessor, IUserService userService, IConfiguration configuration)
        {
            _configuration = configuration;
            _usersService = userService;
            _authRepository = authRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public async Task<User?> AuthenticateUser(UserDto userDTO)
        {
            var allUsers = await _authRepository.GetAllAsync();
            var authorizedUser = allUsers.FirstOrDefault
                (x => x.Username == userDTO.Username && x.Password == HashPassword(userDTO.Password));

            return authorizedUser;
        }

        public async Task<User?> RegisterUser(User user)
        {
            var allUsers = await _authRepository.GetAllAsync();
            var foundUser = allUsers.FirstOrDefault(x => x.Username == user.Username);
            if (foundUser != null) return null;
            user.Password = HashPassword(user.Password);
            await _authRepository.AddAsync(user);

            return user;
        }


        public string GenerateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], null,
                 expires: DateTime.Now.AddMinutes(15),
                 signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
