using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> AuthenticateUser(UserDto userDTO);
        string GenerateToken();
        string HashPassword(string password);
        Task<User?> RegisterUser(User user);
    }
}