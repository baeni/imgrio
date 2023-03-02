using Firebase.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Security.Authentication;
using Imgrio.Blazor.Backend.Interfaces;
using Imgrio.Blazor.Backend.Models;

namespace Imgrio.Blazor.Backend.Services
{
    public class UserAuthService
    {
        private readonly IFirebaseAuthProvider _firebaseAuthProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAuthService(IFirebaseAuthProvider firebaseAuthProvider, IHttpContextAccessor httpContextAccessor, UserState userState)
        {
            _firebaseAuthProvider = firebaseAuthProvider;
            _httpContextAccessor = httpContextAccessor;

            UserState = userState;
        }

        public IUserState UserState { get; }

        public async Task SendPasswordResetEmailAsync(string email)
        {
            await _firebaseAuthProvider.SendPasswordResetEmailAsync(email);
        }

        public async Task SignInAsync(string email, string password)
        {
            try
            {
                var auth = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
                var token = auth.FirebaseToken;

                if (token == null)
                {
                    throw new AuthenticationException("Firebase authentication failed.");
                }

                UserState.FirebaseUser = auth.User;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, auth.User.LocalId),
                    new Claim(ClaimTypes.Email, auth.User.Email),
                    new Claim(ClaimTypes.Name, auth.User.Email.Split('@')[0]),
                    new Claim(ClaimTypes.Role, "User")
                };

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await _httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                    authProperties);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
