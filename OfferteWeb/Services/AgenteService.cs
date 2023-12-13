using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfferteWeb.Models;
using Offerte.Utils;
using OfferteWeb.Models;
using OfferteWeb.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using OfferteWeb.Models.Auth;

namespace OfferteWeb.Services;

public interface IAgenteService : IBaseService<Agente, long, OfferteDbContext>
{
    IEnumerable<Agente> Search(AgenteSearchModel model);
    Agente Update(Agente user);
    Agente Authenticate(string username, string password);
    Task<Agente> AuthenticateAsync(string token);
}

public class AgenteService : BaseService<Agente, long, OfferteDbContext>, IAgenteService
{
    private readonly AuthContext authContext;
    public AgenteService(IConfiguration configuration, AuthContext authContext, OfferteDbContext ctx = null)
        : base(configuration, ctx)
    {
        this.authContext = authContext;
    }

    public IEnumerable<Agente> Search(AgenteSearchModel model)
    {
        return ctx.Agente;
    }

    public Agente Update(Agente user)
    {
        return ctx.Agente.FirstOrDefault();
    }

    public Agente Authenticate(string username, string password)
    {
        var agente = ctx.Agente
            .Include("AgenteGruppo")
            .Where(x => x.Id.ToString() == username && x.Password == password).FirstOrDefault();

        if (agente == null)
            throw new Exception($"Principal not found, {username}");
        agente.Username = agente.Id.ToString();
        if (agente.Supervisore == true)
        {
            agente.Role = Role.ADMIN;
        }
        //if (new string[] { Role.MANAGER, Role.OPERATOR }.Contains(identity.Role) &&
        //    !principal.PrincipalGrouping.Select(x => x.Grouping).Any())
        //    throw new Exception($"Principal without group, {username}");
        List<long> ids = agente.AgenteGruppo.Select(x => x.IdGruppo).ToList();
        List<Gruppo> gruppi = ctx.Gruppo.Where(x => ids.Contains(x.Id)).ToList();
        foreach (Gruppo item in gruppi)
        {
            if (item.DirittoSede) agente.DirittoSede = true;
        }

        var token = generateJwtToken(agente);
        agente.Token = token;
        return agente;
    }

    public async Task<Agente> AuthenticateAsync(string token)
    {
        string secret = configuration["Jwt:Secret"];
        var handler = new JwtSecurityTokenHandler();
        try
        {
            var claimsPrincipal = handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
            string userId = jwtToken.Claims.First(x => x.Type == "userId").Value;
            string userName = jwtToken.Claims.First(x => x.Type == "userName").Value;
            string userEmail = jwtToken.Claims.First(x => x.Type == "userEmail").Value;
            string[] userRoles = jwtToken.Claims.Where(x => x.Type == "userRoles").Select(x => x.Value).ToArray();
            Agente user = new Agente
            {
                //Id = userId,
                Username = userName,
                Mail = userEmail,
                //Roles = userRoles
            };
            return user;
        }
        catch (Exception)
        {
            return null;
        }
    }

    #region PRIVATE token
    private string generateJwtToken(Agente user)
    {
        //var claims = new[] {
        //        new Claim("name", "callbackuser"),
        //        new Claim(ClaimTypes.NameIdentifier, "callbackuser"),
        //        new Claim(ClaimTypes.Name, "callbackuser"),
        //    };
        //var identity = new ClaimsIdentity(claims, Scheme.Name);

        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(authContext.JWTSecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new[] {
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.RagioneSociale),
                    new Claim("username", user.Username),
                }
            ),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    #endregion


}

public class AgenteSearchModel : QueryBuilderSearchModel
{

}
