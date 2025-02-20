using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace OfferteWeb.Pages.Identity
{
    public class LogoutModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            await DoLogout();
            Redirect("~/");
        }

        public async Task DoLogout()
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);            
            //return LocalRedirect(Url.Content("~/"));
        }

        public IActionResult OnPost()
        {
            return Redirect("~/");
            //return LocalRedirect(Url.Content("~/"));
        }
    }
}
