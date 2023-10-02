using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteUserAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task UpdateUserAsync(User user);
    }
}