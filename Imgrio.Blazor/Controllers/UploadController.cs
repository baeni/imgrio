using Imgrio.Blazor.Backend.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> PostUserFileAsync([FromForm] UserFileRequest request)
        {
            // Authorize
            await _userAuthService.SignInAsync(request.Email, request.Password);

            if (!_userAuthService.UserState.IsAuthenticated)
            {
                return Unauthorized("Invalid credentials.");
            }

            // Validate file and extract information
            var file = Request.Form.Files.FirstOrDefault();

            if (file == null)
            {
                return BadRequest("A file must be uploaded.");
            }

            // Save file information to firestore
            var id = await _userFileService.CreateUserFileAsync(_userAuthService.UserState.FirebaseUser, file);

            return Ok($"https://imgrio.azurewebsites.net/f/{id}");
        }

        public class UserFileRequest
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }
    }
}
