using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using OfferteWeb.State;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace OfferteWeb.Handler;

public class InitialApplicationStateHandler
{
    private readonly ILogger<InitialApplicationStateHandler> logger;
    private readonly IAntiforgery Xsrf;

    //private readonly AuthDataService authDataService;

    public InitialApplicationStateHandler(IAntiforgery xsrf,/* AuthDataService authDataService,*/ ILogger<InitialApplicationStateHandler> logger)
    {
        Xsrf = xsrf;
        //this.authDataService = authDataService;
        this.logger = logger;
    }

    public async Task<InitialApplicationState> InitializeStateAndProcessUserPresent(HttpContext HttpContext)
    {
        InitialApplicationState initialApplicationState = new InitialApplicationState
        {
            AuthData = new AuthData()
        };
        initialApplicationState.AuthData.Id = HttpContext.User?.FindFirst("Id")?.Value;
        initialApplicationState.AuthData.Username = HttpContext.User?.FindFirst("Username")?.Value;
        initialApplicationState.AuthData.Role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;

        return initialApplicationState;
    }
}