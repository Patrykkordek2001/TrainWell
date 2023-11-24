using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Database;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.User;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlRepository<User> _userRepository;
        private readonly ISqlRepository<UserInfo> _userInfoRepository;
        private readonly TrainWellDbContext _context;
        private readonly IMapper _mapper;

        private readonly ICurrentUserProvider _currentUserProvider;
        public UserService(IMapper mapper,ISqlRepository<User> userRepository, ICurrentUserProvider currentUserProvider, ISqlRepository<UserInfo> userInfoRepository, TrainWellDbContext context)
        {
            _context= context;
            _mapper = mapper;
            _userRepository = userRepository;
            _currentUserProvider = currentUserProvider;
            _userInfoRepository = userInfoRepository;
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

            var user = await _userRepository
                    .Include(u => u.UserInfo)
                    .FirstOrDefaultAsync(u => u.Id == userId);
            var x = _context.Users.Include(u => u.UserInfo).FirstOrDefault(x=>x.Id==userId);
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task<UserInfo> UpdateOrAddUserInfoAsync(UserInfoDto userInfoDto)
        {
            var userInfo = _mapper.Map<UserInfo>(userInfoDto);


            var existingUserInfo = await _context.UserInfos
                .FirstOrDefaultAsync(u => u.UserId == userInfo.UserId);

            if (existingUserInfo != null)
            {
                existingUserInfo.Weight = userInfo.Weight;
                existingUserInfo.Growth = userInfo.Growth;
                existingUserInfo.Age = userInfo.Age;
                existingUserInfo.Activity = userInfo.Activity;
                existingUserInfo.Gender = userInfo.Gender;

                existingUserInfo.CalculateDailyCalories();

                _context.UserInfos.Update(existingUserInfo);
            }
            else
            {
                userInfo.CalculateDailyCalories();

                _context.UserInfos.Add(userInfo);
            }

            await _context.SaveChangesAsync();

            return userInfo; 
        }


    }
}
