﻿namespace OfferteWeb.Models.Auth
{
    public class AuthContext
    {
        public string JWTSecretKey { get; set; }
        public string JWTLifespan { get; set; }
    }
}
