//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Imgrio.Blazor.Backend.Services;
//using Imgrio.Blazor.Controllers;
//using Microsoft.AspNetCore.Components;

//namespace Imgrio.Blazor.Pages.User
//{
//    public class SignInRedirectModel : PageModel
//    {
//        private readonly UserAuthService _userAuthService;

//        public SignInRedirectModel(UserAuthService userAuthService)
//        {
//            _userAuthService = userAuthService;
//        }

//        public async Task<ActionResult> OnGetAsync(string email, string password)
//        {
//            await _userAuthService.SignInAsync(email, password);

//            if (_userAuthService.UserState.FirebaseUser == null)
//            {
//                return LocalRedirect("/u/sign-in#Credentials");
//            }
//            else if (!_userAuthService.UserState.IsAuthenticated)
//            {
//                // This one gets called. Why? Even though it gets
//                // redirected to /u/files#HttpContext
//                return LocalRedirect("/u/sign-in#HttpContext");
//            }

//            return LocalRedirect("/u/files");
//        }
//    }
//}
