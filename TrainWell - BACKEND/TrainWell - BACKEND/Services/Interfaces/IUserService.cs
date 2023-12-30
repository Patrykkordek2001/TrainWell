using TrainWell___BACKEND.Dtos.Users;
using TrainWell___BACKEND.Models.Users;

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