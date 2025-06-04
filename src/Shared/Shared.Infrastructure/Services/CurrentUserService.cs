using Microsoft.AspNetCore.Http;
using Shared.Core.Interfaces;

namespace Shared.Infrastructure.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
    }
}
