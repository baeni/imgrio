using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fordele.Blazor.Pages.User
{
    public class SignOutRedirectModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SignOutRedirectModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult> OnGetAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();

            return LocalRedirect("/");
        }
    }
}
