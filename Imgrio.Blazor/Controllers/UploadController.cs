using Imgrio.Blazor.Backend.Services;
using Imgrio.Blazor.Pages.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Imgrio.Blazor.Controllers
{
    [ApiController]
    [Route("api/v1/upload")]
    public class UploadController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserFileService _userFileService;

        public UploadController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, UserFileService userFileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userFileService = userFileService;
        }

        [HttpPost("credentials")]
        public async Task<IActionResult> PostUserFileWithCredentialsAsync([FromForm] SignInModel.InputModel input)
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

            if (file.Length > Constants.MaxFileSizeInBytes)
            {
                return BadRequest($"Die Datei darf maximal {Constants.MaxFileSizeInBytes / 1000000}MB groß sein.");
            }
            #endregion

            var id = await _userFileService.CreateUserFileAsync(user, file);

            return Ok($"https://imgrio.azurewebsites.net{Constants.PathToFileView}{id}");
        }

        [HttpPost("user")]
        [Authorize]
        public async Task<IActionResult> PostUserFileWithUserAsync([FromForm] IdentityUser user)
        {
            #region Authorize
            if (user == null)
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

            if (file.Length > Constants.MaxFileSizeInBytes)
            {
                return BadRequest($"Die Datei darf maximal {Constants.MaxFileSizeInBytes / 1000000}MB groß sein.");
            }
            #endregion

            var id = await _userFileService.CreateUserFileAsync(user, file);

            return Ok($"https://imgrio.azurewebsites.net{Constants.PathToFileView}{id}");
        }
    }
}
