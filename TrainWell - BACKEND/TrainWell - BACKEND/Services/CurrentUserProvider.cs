using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<int> GetUserIdAsync()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(userId);

        }
    }
}