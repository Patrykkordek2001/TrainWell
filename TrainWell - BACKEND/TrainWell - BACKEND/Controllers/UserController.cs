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

        [HttpPost("updateOrAddUserInfo")]
        public async Task<ActionResult> UpdateOrAddUserInfo(UserInfoDto userInfoDto)
        {
            try
            {
                var updatedUserInfo = await _userService.UpdateOrAddUserInfoAsync(userInfoDto);
                //var updatedUserInfoDto = _mapper.Map<UserInfoDto>(updatedUserInfo);

                return Ok(updatedUserInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
