using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using OfferteWeb.Services;

namespace OfferteWeb.Handler;
//public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationHandlerOptions>
//{
//    private readonly IIdentityService _identityService;
//    public CustomAuthenticationHandler(IOptionsMonitor<CustomAuthenticationHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IIdentityService identityService) : base(options, logger, encoder, clock)
//    {
//        _identityService = identityService;
//    }
//    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//    {
//        string token = null;
//        if (Request.Headers.ContainsKey("Authorization"))
//        {
//            string headerValue = Request.Headers["Authorization"];
//            if (headerValue.StartsWith("Bearer "))
//            {
//                token = headerValue.Substring("Bearer ".Length);
//            }
//        }
//        if (string.IsNullOrEmpty(token))
//        {
//            return AuthenticateResult.Fail("Invalid token");
//        }
//        ClaimsIdentity identity = null;
//        // TODO: Validate token and create claims identity
//        if (identity == null)
//        {
//            return AuthenticateResult.Fail("Invalid token");
//        }
//        AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), Options.Scheme);
//        return AuthenticateResult.Success(ticket);
//    }
//}
