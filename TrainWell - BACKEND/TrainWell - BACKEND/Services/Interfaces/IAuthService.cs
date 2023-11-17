using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.User;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> AuthenticateUser(UserDto userDTO);
        string GenerateToken(User user);
        string HashPassword(string password);
        Task<User?> RegisterUser(User user);
    }
}