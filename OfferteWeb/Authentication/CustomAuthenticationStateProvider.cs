using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using OfferteWeb.State;

namespace OfferteWeb.Authentication;
public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ProtectedSessionStorage _sessionStorage;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage, NavigationManager navManager)
    {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSessionStorageResult = await _sessionStorage.GetAsync<AuthData>("authData");
            var authData = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
            if (authData == null)
                return await Task.FromResult(new AuthenticationState(_anonymous));
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, authData.Username),
                new Claim(ClaimTypes.Role, authData.Role),
            }, "CustomAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        catch (Exception e)
        {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

    public async Task UpdateUserAuthenticated(AuthData authData)
    {
        ClaimsPrincipal claimsPrincipal;
        if (authData != null)
        {
            await _sessionStorage.SetAsync("authData", authData);
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, authData.Username),
                new Claim(ClaimTypes.Role, authData.Role),
            }, "CustomAuth"));
        }
        else
        {
            await _sessionStorage.DeleteAsync("authData");
            claimsPrincipal = _anonymous;
        }
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public void UserLoggedOut()
    {
        _sessionStorage.DeleteAsync("authData");
        //var identity = new ClaimsIdentity();
        //var user = new ClaimsPrincipal(identity);
        ClaimsPrincipal claimsPrincipal = _anonymous;
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

    }
}
