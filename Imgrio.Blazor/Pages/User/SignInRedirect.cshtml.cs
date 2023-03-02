using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
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
            await _userAuthService.SignInAsync(email, password);

            if (_userAuthService.UserState.IsAuthenticated)
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
