using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> GetUserIdAsync()
        {
            var userId = "";

            if (_httpContextAccessor.HttpContext != null)
            {
                userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            } else return 0;

              return int.Parse(userId);

        }
    }
}