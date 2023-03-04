using Imgrio.Blazor.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Imgrio.Blazor.Pages.Account;
using Microsoft.AspNetCore.Identity;

namespace Imgrio.Blazor.Controllers
{
    [ApiController]
    [Route("api/v1/upload")]
    public class UserFileController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserFileService _userFileService;

        public UserFileController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, UserFileService userFileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userFileService = userFileService;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserFileAsync([FromForm] SignInModel.InputModel input)
        {
            #region Authorize
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user == null || user.UserName == null)
            {
                return Unauthorized("Überprüfe deine Anmeldedaten.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, input.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized("Überprüfe deine Anmeldedaten.");
            }
            #endregion

            #region Validate file and extract information
            var file = Request.Form.Files.FirstOrDefault();

            if (file == null)
            {
                return BadRequest("Es muss eine Datei hochgeladen werden.");
            }
            #endregion

            var id = await _userFileService.CreateUserFileAsync(user, file);

            return Ok($"https://imgrio.azurewebsites.net/f/{id}");
        }
    }
}
