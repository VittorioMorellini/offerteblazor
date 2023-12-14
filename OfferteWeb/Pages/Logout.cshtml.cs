using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using OfferteWeb.Authentication;
using OfferteWeb.State;

namespace OfferteWeb.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public LogoutModel(AuthenticationStateProvider authenticationStateProvider, NavigationManager navManager)
        {
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task OnGetAsync(string redirectUri)
        {
            await DoLogout(redirectUri);
        }

        public async Task DoLogout(string redirectUri)
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
            customAuthStateProvider.UserLoggedOut();
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //await HttpContext.SignOutAsync(new AuthenticationProperties
            //{
            //    RedirectUri = redirectUri,
            //}); 
            Response.Redirect("/");
        }
    }
}
