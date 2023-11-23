using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.User;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var currentUser = await _userService.GetCurrentUser();
            
            return currentUser;
        }

        [HttpPost("UpdateOrAddUserInfoAsync")]
        public async Task<ActionResult<UserInfo>> UpdateOrAddUserInfoAsync(UserInfoDto )
        {
            var currentUser = await _userService.UpdateOrAddUserInfoAsync();

            return currentUser;
        }


    }
}
