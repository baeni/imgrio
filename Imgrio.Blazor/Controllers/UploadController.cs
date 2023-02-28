using Firebase.Auth;
using Imgrio.Blazor.Backend.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace Imgrio.Blazor.Controllers
{
    [ApiController]
    [Route("api/v1/upload")]
    public class UserFileController : ControllerBase
    {
        private readonly FirebaseAuthHandler _firebaseAuthHandler;
        private readonly UserFileService _userFileService;
        private readonly FirestoreDb _firestoreDb;

        public UserFileController(FirebaseAuthHandler firebaseAuthHandler, UserFileService userFileService, FirestoreDb firestoreDb)
        {
            _userFileService = userFileService;
            _firebaseAuthHandler = firebaseAuthHandler;
            _firestoreDb = firestoreDb;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserFileAsync([FromForm] UserFileRequest request)
        {
            // Authorize
            FirebaseAuthLink? auth;
            try
            {
                auth = await _firebaseAuthHandler.FirebaseAuthProvider.SignInWithEmailAndPasswordAsync(request.Email, request.Password);
                var token = auth.FirebaseToken;

                if (token == null)
                {
                    return Unauthorized("Invalid credentials.");
                }
            }
            catch (FirebaseAuthException)
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
            var id = await _userFileService.CreateUserFileAsync(auth.User, file);

            return Ok($"https://imgrio.azurewebsites.net/f/{id}");
        }

        public class UserFileRequest
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }
    }
}
