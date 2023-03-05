using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Imgrio.Blazor.Pages.Auth
{
    public class SignOutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public SignOutModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();

            return LocalRedirect("/");
        }
    }
}
