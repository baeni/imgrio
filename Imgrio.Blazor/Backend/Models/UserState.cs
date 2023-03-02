using Firebase.Auth;
using Imgrio.Blazor.Backend.Interfaces;
using System.Security.Claims;

namespace Imgrio.Blazor.Backend.Models
{
    public class UserState : IUserState
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserState(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User? FirebaseUser { get; set; }

        public bool IsAuthenticated => FirebaseUser != null && _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated == true;

        public string Id => FirebaseUser?.LocalId ?? _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public string Email => FirebaseUser?.Email ?? _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

        public string Name => FirebaseUser?.DisplayName ?? _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

        public string Role => _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
    }
}
