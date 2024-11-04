using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using OfferteWeb.Authentication;
using OfferteWeb.Models;
using OfferteWeb.Services;
using OfferteWeb.State;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace OfferteWeb.Pages.Identity
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IAgenteService agenteService;
        private ILogger<LoginModel> _logger;
        public LoginModel(IAgenteService agenteService, ILogger<LoginModel> logger)
        {
            this.agenteService = agenteService;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        //public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            //Error = false;
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                // Use Input.Email and Input.Password to authenticate the user
                // with your custom authentication logic.
                //
                // For demonstration purposes, the sample validates the user
                // on the email address maria.rodriguez@contoso.com with 
                // any password that passes model validation.
                try
                {
                    Agente agente = agenteService.Authenticate(Input.Username, Input.Password);
                    if (agente == null)
                    {
                        ModelState.AddModelError("LoginError", "Invalid login attempt.");
                        return Page();
                    }
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, agente.Nome),
                        new Claim(ClaimTypes.Surname, agente.Cognome),
                        new Claim("Id", agente.Id.ToString()),
                        new Claim("FullName", agente.RagioneSociale),
                        new Claim(ClaimTypes.Role, "Administrator"),
                        new Claim(ClaimTypes.Email, agente.Mail),
                        new Claim(ClaimTypes.Surname, agente.Cognome),
                        new Claim(ClaimTypes.MobilePhone, agente.Telefono ?? ""),
                        new Claim("Username", Input.Username),
                        new Claim("Password", Input.Password),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    _logger.LogInformation("User {Email} logged in at {Time}.", agente.Mail, DateTime.UtcNow);
                    Console.WriteLine("Login OK!");
                    //return LocalRedirect(Url.RouteUrl(ReturnUrl));
                    return Redirect("~/");
                }
                catch (Exception ex)
                {
                    //Error = true;
                    ModelState.AddModelError("LoginError", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("LoginError", "Login credential are not valid");
            }
            return Page();

            //await HttpContext.sign
            //Console.WriteLine("Login to do");
            //localStorage set user
            //AuthData authData = new AuthData
            //{
            //    Id = agente.Id.ToString(),
            //    Username = agente.Username,
            //    Role = agente.Role,
            //    Mail = agente.Mail != null ? agente.Mail : "",
            //    RagioneSociale = agente?.RagioneSociale,
            //    Token = agente.Token
            //};
            //var customAuthStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
            //await customAuthStateProvider.UpdateUserAuthenticated(authData);
        }

        public class InputModel
        {
            [Required]
            //[Username]
            public string Username { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }
}
