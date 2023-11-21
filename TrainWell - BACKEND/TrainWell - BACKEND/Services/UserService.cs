using TrainWell___BACKEND.Models.User;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlRepository<User> _userRepository;
        private readonly ICurrentUserProvider _currentUserProvider;
        public UserService(ISqlRepository<User> userRepository, ICurrentUserProvider currentUserProvider)
        {
            _userRepository = userRepository;
            _currentUserProvider = currentUserProvider;
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int  id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetCurrentUser()
        {
            var userId = await _currentUserProvider.GetUserIdAsync();

            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
    }
}
