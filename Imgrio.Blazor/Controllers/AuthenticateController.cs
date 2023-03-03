using Imgrio.Blazor.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imgrio.Blazor.Controllers
{
    [ApiController]
    [Route("api/v1/authenticate")]
    public class AuthenticateController : Controller
    {
        private readonly UserAuthService _userAuthService;

        public AuthenticateController(UserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthenticateAsync([FromBody] AuthenticateModel model)
        {
            await _userAuthService.SignInAsync(model.Email, model.Password);

            if (_userAuthService.UserState.FirebaseUser == null)
            {
                return Unauthorized("Überprüfe deine Anmeldedaten.");
            }
            //else if (!_userAuthService.UserState.IsAuthenticated)
            //{
            //    return Unauthorized("Es gab einen unerwarteten Fehler mit der HttpContext Authentifizierung.");
            //}

            return Ok("Authentifizierung erfolgreich.");
        }

        public class AuthenticateModel
        {
            public string Email { get; set; } = null!;

            public string Password { get; set; } = null!;
        }
    }
}
