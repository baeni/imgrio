using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Imgrio.Blazor.Pages.Account
{
    public class SignInModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public SignInModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string ReturnUrl { get; set; } = string.Empty;

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");

            if (!ModelState.IsValid)
            {
                //Alert = "Bitte fülle alle Felder aus.";
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null || user.UserName == null)
            {
                //Alert = "Überprüfe deine Anmeldedaten.";
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, Input.Password, isPersistent: true, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                //Alert = "Überprüfe deine Anmeldedaten.";
                return Page();
            }

            return LocalRedirect(ReturnUrl);
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
        }
    }
}
