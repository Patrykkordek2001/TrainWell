﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TrainWell___BACKEND.Dtos.Users;
using TrainWell___BACKEND.Models.Users;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

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

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                 expires: DateTime.Now.AddMinutes(6),
                 signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string RefreshToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                var handler = new JwtSecurityTokenHandler();
                var originalToken = handler.ReadToken(token) as JwtSecurityToken;

                if (originalToken != null)
                {
                    var newToken = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: originalToken.ValidTo,
                        signingCredentials: credentials
                    );

                    return new JwtSecurityTokenHandler().WriteToken(newToken);
                }
            }
            return null;
        }
    }
}