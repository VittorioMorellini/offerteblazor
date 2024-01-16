using OfferteWeb.Services;
using OfferteWeb.Exceptions;
using OfferteWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace OfferteWeb.State;

public class AppState
{
    private bool Initialized = false;
    public HttpContext httpContext { get; set; }
    private IAgenteService _agenteService;
    public Agente? User { get; set; }
    public AppState(IAgenteService agenteService)
    {
        _agenteService = agenteService;
    }
    public void Initialize(InitialApplicationState InitialState)
    {
        var userId = InitialState?.AuthData?.Id;
        User = _agenteService.Find(Convert.ToInt64(userId));

        if (User == null || User != null && User.ExpirationDate.HasValue && User.ExpirationDate < DateTime.Now)
        {
            throw new AuthorizeException(401);
        }
        if (User != null && User.Disabled == true)
        {
            throw new AuthorizeException(403);
        }
        //Initialized = true;
    }

    public string? Username
    {
        get
        {
            if (User == null)
            {
                throw new AuthorizeException(401);
            }
            return User?.Username;
        }
    }
}
