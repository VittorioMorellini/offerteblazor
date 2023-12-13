using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfferteWeb.Models;

namespace OfferteWeb.Models.Auth
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Agente user, string token)
        {
            Id = user.Id;
            Name = user.RagioneSociale;
            //Surname = user.Surname;
            Username = user.Username;
            Token = token;
        }
    }
}
