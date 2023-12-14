using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace OfferteWeb.Pages
{
    public class LogoutModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            await DoLogout();
        }

        public async Task DoLogout()
        {
            //if (!string.IsNullOrEmpty(ErrorMessage))
            //{
            //    ModelState.AddModelError(string.Empty, ErrorMessage);
            //}
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //return LocalRedirect(Url.Content("~/"));
            //return Redirect("~/");
            //return LocalRedirect(Url.Content("~/"));
        }

        public IActionResult OnPost()
        { 
            return Redirect("~/");
            //return LocalRedirect(Url.Content("~/"));
        }
    }
}
