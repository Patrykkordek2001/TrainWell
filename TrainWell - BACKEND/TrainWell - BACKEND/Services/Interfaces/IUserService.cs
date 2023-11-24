using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.User;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteUserAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetCurrentUser();
        Task<User> GetUserByIdAsync(int id);
        Task<UserInfo> UpdateOrAddUserInfoAsync(UserInfoDto userInfo);
        Task UpdateUserAsync(User user);
    }
}