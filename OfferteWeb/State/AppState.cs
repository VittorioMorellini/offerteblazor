using OfferteWeb.Services;
using OfferteWeb.Exceptions;
using OfferteWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace OfferteWeb.State;

public class AppState
{
    private bool Initialized = false;
    //private HttpContext httpContext { get; set; }
    private readonly IAgenteService _agenteService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private string _username;
    private string _role;
    public Agente? User { get; set; }
    public AppState(IAgenteService agenteService, IHttpContextAccessor httpContextAccessor)
    {
        _agenteService = agenteService;
        _httpContextAccessor = httpContextAccessor;
    }
    public void Initialize()
    {
        //var userId = InitialState?.AuthData?.Id;
        var userId = _httpContextAccessor.HttpContext.User?.FindFirst("Id")?.Value;
        _username = _httpContextAccessor.HttpContext.User?.FindFirst("Username")?.Value;
        _role = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
        // initialState.AuthData.Token = _httpContextAccessor.HttpContext.User?.FindFirst("Token")?.Value;
        User = _agenteService.Find(Convert.ToInt64(userId));

        if (User == null || User != null && User.ExpirationDate.HasValue && User.ExpirationDate < DateTime.Now)
        {
            throw new AuthorizeException(401);
        }
        if (User != null && User.Disabled == true)
        {
            throw new AuthorizeException(403);
        }
        Initialized = true;
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
    public string? Role
    {
        get
        {
            if (User == null)
            {
                throw new AuthorizeException(401);
            }
            return User?.Role;
        }
    }
}
