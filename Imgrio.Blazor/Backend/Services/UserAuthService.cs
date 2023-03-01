using Firebase.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Security.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace Imgrio.Blazor.Backend.Services
{
    public class UserAuthService
    {
        private readonly IFirebaseAuthProvider _firebaseAuthProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserAuthService(
            IFirebaseAuthProvider firebaseAuthProvider,
            IHttpContextAccessor httpContextAccessor,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _firebaseAuthProvider = firebaseAuthProvider;
            _httpContextAccessor = httpContextAccessor;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<ClaimsPrincipal> GetUserAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.User;
        }

        public async Task SendPasswordResetEmailAsync(string email)
        {
            await _firebaseAuthProvider.SendPasswordResetEmailAsync(email);
        }

        public async Task<User?> SignInAsync(string email, string password)
        {
            try
            {
                var auth = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
                var token = auth.FirebaseToken;

                if (token == null)
                {
                    throw new AuthenticationException("Firebase authentication failed.");
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, auth.User.LocalId),
                    new Claim(ClaimTypes.Name, auth.User.Email.Split('@')[0]),
                    new Claim(ClaimTypes.Email, auth.User.Email),
                    new Claim(ClaimTypes.Role, "User"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await _httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return auth.User;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
