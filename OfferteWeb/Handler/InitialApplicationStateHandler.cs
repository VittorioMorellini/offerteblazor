using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using OfferteWeb.Services;
using OfferteWeb.State;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace OfferteWeb.Handler;
// It is not called from anywhere
public class InitialApplicationStateHandler
{
    private readonly ILogger<InitialApplicationStateHandler> logger;
    private readonly IAntiforgery Xsrf;
    private readonly AgenteService agenteService;
    // private readonly InitialApplicationStateHandlerOptions initialApplicationStateHandlerOptions;

    public InitialApplicationStateHandler(IAntiforgery xsrf, ILogger<InitialApplicationStateHandler> logger, 
        AgenteService agenteService
        //InitialApplicationStateHandlerOptions initialApplicationStateHandlerOptions
        )
    {
        this.Xsrf = xsrf;
        this.agenteService = agenteService;
        this.logger = logger;
        //this.initialApplicationStateHandlerOptions = initialApplicationStateHandlerOptions;
    }

    //public InitialApplicationState InitializeStateAndProcessUserPresent(HttpContext HttpContext)
    //{
    //    InitialApplicationState initialApplicationState = new InitialApplicationState
    //    {
    //        AuthData = new AuthData()
    //    };
    //    initialApplicationState.AuthData.Id = HttpContext.User?.FindFirst("Id")?.Value;
    //    initialApplicationState.AuthData.Username = HttpContext.User?.FindFirst("Username")?.Value;
    //    initialApplicationState.AuthData.Role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;

    //    initialApplicationState.AuthData.Token = HttpContext.User?.FindFirst("Token")?.Value;
    //    initialApplicationState.AuthData.User = agenteService.Find(Convert.ToInt64(initialApplicationState.AuthData.Id));

    //    return initialApplicationState;
    //}
}
