using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Imgrio.Blazor.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;

        //public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //}

        //[BindProperty]
        //public InputModel Input { get; set; } = new InputModel();

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        //Alert = "Bitte fülle alle Felder aus.";
        //        return Page();
        //    }

        //    var identity = new IdentityUser { UserName = Input.Username, Email = Input.Email };
        //    var result = await _userManager.CreateAsync(identity, Input.Password);
        //    if (!result.Succeeded)
        //    {
        //        //Alert = $"Bitte behebe folgende Probleme:{Environment.NewLine}";

        //        foreach (var error in result.Errors)
        //        {
        //            //Alert += $"- {error.Code}{Environment.NewLine}";
        //        }

        //        return Page();
        //    }

        //    await _signInManager.SignInAsync(identity, isPersistent: true);
        //    return LocalRedirect(Constants.PathToDashboardUpload);
        //}

        //public class InputModel
        //{
        //    [Required, MinLength(4), MaxLength(24)]
        //    [DataType(DataType.Text)]
        //    public string Username { get; set; } = string.Empty;

        //    [Required]
        //    [EmailAddress]
        //    public string Email { get; set; } = string.Empty;

        //    [Required]
        //    [DataType(DataType.Password)]
        //    public string Password { get; set; } = string.Empty;
        //}
    }
}
