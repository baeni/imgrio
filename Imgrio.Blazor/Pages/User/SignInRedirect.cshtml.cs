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
        private readonly UserAuthService _userAuthService;

        public SignInRedirectModel(UserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        public async Task<ActionResult> OnGetAsync(string email, string password)
        {
            var user = await _userAuthService.SignInAsync(email, password);

            if (user != null)
            {
                return LocalRedirect("/u/files");
            }
            else
            {
                return LocalRedirect("/u/sign-in");
            }
        }
    }
}
