using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
// using LazyCache;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfferteWeb.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using OfferteWeb.Models.Auth;

namespace OfferteWeb.Services
{
    public interface IIdentityService
    {

        ClaimsPrincipal GetUser();
        string GetSxUser();
        string GetName();
        bool IsInRole(string role);
        bool IsRoleAtLeast(string role);

        Agente Authenticate(string username, string password);
        long GetPrincipalId(string username);

        long GetIdentityId();
        string GetUserAgent();

    }

    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor context;
        private readonly AuthContext authContext;
        private OfferteDbContext ctx;
        private readonly IConfiguration _configuration;

        public IdentityService(IHttpContextAccessor context, AuthContext authContext, IConfiguration configuration, OfferteDbContext ctx)
        {
            this.context = context;
            this.authContext = authContext;
            ArgumentNullException.ThrowIfNull(ctx);
            this.ctx = ctx; //?? new OfferteDbContext();
            _configuration = configuration;
        }

        public string GetUserAgent()
        {
            string userAgent = "";
            if (context.HttpContext.Request.Headers.TryGetValue("User-Agent", out var headers))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var header in headers)
                {
                    sb.Append(header);
                    sb.Append(" ");
                }

                userAgent = sb.ToString().Trim();
            }
            return userAgent;
        }
        private ClaimsPrincipal User { get => context.HttpContext.User; }
        public ClaimsPrincipal GetUser()
        {
            return User;
        }
        public string GetSxUser()
        {
            //return User?.Claims.Where(x => x.Type == "sx.user").FirstOrDefault()?.Value;
            return User?.Claims.Where(x => x.Type == "name").FirstOrDefault()?.Value;
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        public bool IsRoleAtLeast(string role)
        {
            return false;
        }

        public string GetName()
        {
            return GetSxUser();
        }

        public long GetPrincipalId(string username)
        {
            return ctx.Agente
                .Where(x => x.Id.ToString() == username)
                .FirstOrDefault()?.Id ?? 0;
        }

        public long GetIdentityId()
        {
            string id = User?.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;
            return Convert.ToInt64(id);
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
            //if (identity.Role != Role.ADMIN)
            //    throw new Exception($"Principal not valid, {username}");

            //if (new string[] { Role.MANAGER, Role.OPERATOR }.Contains(identity.Role) &&
            //    !principal.PrincipalGrouping.Select(x => x.Grouping).Any())
            //    throw new Exception($"Principal without group, {username}");
            List<long> ids = agente.AgenteGruppo.Select(x => x.IdGruppo).ToList();
            List<Gruppo> gruppi = ctx.Gruppo.Where(x => ids.Contains(x.Id)).ToList();
            foreach (Gruppo item in gruppi)
            {
                if (item.DirittoSede) agente.DirittoSede = true;
            }

            var token = ""; //generateJwtToken(agente);
            agente.Token = token;
            return agente;
        }

        
        //public AuthenticateResponse Authenticate(string username, string password)
        //{
        //    var user = ctx.Principal.SingleOrDefault(x => x.Username == username && x.Password == password);

        //    // return null if user not found
        //    if (user == null) return null;

        //    // authentication successful so generate jwt token
        //    var token = generateJwtToken(user);

        //    return new AuthenticateResponse(user, token);
        //}        

        //public long GetAuthorizationFromHeader()
        //{
        //    if (context.HttpContext.Request.Headers.TryGetValue("sx-auth-id", out var idAutorizzazione))
        //    {
        //        return long.Parse(idAutorizzazione);
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid authorization header");
        //    }
        //}

        public class ClientFilter
        {

        }

        public class AutorizzazioneRisorsa
        {
            public string value { get; set; }
            public string description { get; set; }
        }

    }

    public class IdentityMockService : IIdentityService
    {
        private readonly string id;
        private readonly string userAgent;

        public IdentityMockService(string id, string userAgent)
        {
            this.id = id;
            this.userAgent = userAgent;
        }

        public ClaimsPrincipal GetUser()
        {
            return new ClaimsPrincipal();
        }

        public string GetName()
        {
            return id;
        }

        public string GetUserAgent()
        {
            return userAgent;
        }


        public bool IsInRole(string ruolo)
        {
            return false;
        }

        public long GetIdentityId()
        {
            throw new NotImplementedException();
        }
        public string GetSxUser()
        {
            throw new NotImplementedException();
        }

        public async Task<Agente> AuthenticateAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Agente Authenticate(string username, string password)
        {
            //var user = ctx.Principal.SingleOrDefault(x => x.Username == username && x.Password == password);
            return new Agente()
            {
                //IdPartizione = 0,
                //Id = 76,
                Username = username,
                Password = password
            };
        }

        public bool IsRoleAtLeast(string ruolo)
        {
            throw new NotImplementedException();
        }

        public long GetPrincipalId(string username)
        {
            throw new NotImplementedException();
        }

    }

    
}
