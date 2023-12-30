using TrainWell___BACKEND.Dtos.Users;
using TrainWell___BACKEND.Models.Users;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> AuthenticateUser(UserDto userDTO);

        string GenerateToken(User user);

        string HashPassword(string password);

        string RefreshToken(User user);

        Task<User?> RegisterUser(User user);
    }
}