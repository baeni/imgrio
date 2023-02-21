using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Firebase.Auth;
using Imgrio.Blazor.Backend.Services;

namespace Imgrio.Blazor.Pages.User
{
    public class SignInRedirectModel : PageModel
    {
        private readonly FirebaseAuthHandler _firebaseAuthHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SignInRedirectModel(FirebaseAuthHandler firebaseAuthHandler, IHttpContextAccessor httpContextAccessor)
        {
            _firebaseAuthHandler = firebaseAuthHandler;
            _httpContextAccessor = httpContextAccessor;
        }

        public string ReturnUrl { get; set; }

        public async Task<ActionResult> OnGetAsync(string email, string password)
        {
            ReturnUrl = Url.Content("~/");

            try
            {
                var auth = await _firebaseAuthHandler.FirebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
                var token = auth.FirebaseToken;

                if (token == null)
                {
                    return LocalRedirect("/u/sign-in");
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, auth.User.LocalId),
                    new Claim(ClaimTypes.Name, auth.User.Email),
                    new Claim(ClaimTypes.Role, "User"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await _httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }
            catch (FirebaseAuthException)
            {
                return LocalRedirect("/u/sign-in");
            }

            return LocalRedirect("/u/files");
        }
    }
}
