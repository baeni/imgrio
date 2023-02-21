using Firebase.Auth;
using Fordele.Blazor.Backend.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace Fordele.Blazor.Controllers
{
    [ApiController]
    [Route("api/v1/upload")]
    public class UserFileController : ControllerBase
    {
        private readonly UserFileService _userFileService;
        private readonly FirebaseAuthHandler _firebaseAuthHandler;

        public UserFileController(UserFileService userFileService, FirebaseAuthHandler firebaseAuthHandler)
        {
            _userFileService = userFileService;
            _firebaseAuthHandler = firebaseAuthHandler;
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

            var id = Guid.NewGuid().ToString();
            var title = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            var size = file.Length;
            var uploadedAt = DateTime.UtcNow;
            var uploadedBy = auth.User.LocalId;

            if (extension.StartsWith('.'))
            {
                extension = extension.Substring(1);
            }

            // Save file to disk
            using (var fileStream = new FileStream(Path.Combine(_userFileService.DataPath, $"{id}.{extension}"), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Save file information to firestore
            var db = FirestoreDb.Create("fordele");

            var docRef = db.Collection("files").Document(id);
            var fields = new Dictionary<string, object>
            {
                { "title", title },
                { "extension", extension },
                { "size", size },
                { "uploadedAt", uploadedAt },
                { "uploadedBy", uploadedBy }
            };
            await docRef.SetAsync(fields);

            return Ok($"https://fildele.azurewebsites.net/f/{id}");
        }

        public class UserFileRequest
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }
    }
}
