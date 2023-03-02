using Imgrio.Blazor.Backend.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Imgrio.Blazor.Controllers
{
    [ApiController]
    [Route("api/v1/upload")]
    public class UserFileController : ControllerBase
    {
        private readonly UserAuthService _userAuthService;
        private readonly UserFileService _userFileService;
        private readonly FirestoreDb _firestoreDb;

        public UserFileController(UserAuthService userAuthService, UserFileService userFileService, FirestoreDb firestoreDb)
        {
            _userFileService = userFileService;
            _userAuthService = userAuthService;
            _firestoreDb = firestoreDb;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserFileAsync([FromForm] UserFileModel model)
        {
            // Authorize
            await _userAuthService.SignInAsync(model.Email, model.Password);

            if (_userAuthService.UserState.FirebaseUser == null)
            {
                return Unauthorized("Überprüfe deine Anmeldedaten.");
            }
            else if (!_userAuthService.UserState.IsAuthenticated)
            {
                return Unauthorized("Es gab einen unerwarteten Fehler mit der HttpContext Authentifizierung.");
            }

            // Validate file and extract information
            var file = Request.Form.Files.FirstOrDefault();

            if (file == null)
            {
                return BadRequest("Es muss eine Datei hochgeladen werden.");
            }

            // Save file information to firestore
            var id = await _userFileService.CreateUserFileAsync(_userAuthService.UserState.FirebaseUser, file);

            return Ok($"https://imgrio.azurewebsites.net/f/{id}");
        }

        public class UserFileModel
        {
            public string Email { get; set; } = null!;

            public string Password { get; set; } = null!;
        }
    }
}
