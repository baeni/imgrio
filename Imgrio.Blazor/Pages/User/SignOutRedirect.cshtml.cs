using Imgrio.Blazor.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Imgrio.Blazor.Pages.User
{
    public class SignOutRedirectModel : PageModel
    {
        private readonly UserAuthService _userAuthService;

        public SignOutRedirectModel(UserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        public async Task<ActionResult> OnGetAsync()
        {
            await _userAuthService.SignOutAsync();

            return LocalRedirect("/");
        }
    }
}
