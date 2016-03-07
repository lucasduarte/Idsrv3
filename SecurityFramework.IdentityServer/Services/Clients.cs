using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityFramework.IdentityServer.Services
{
    public static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    Enabled = true,
                    ClientName = "Identity Manager API",
                    ClientId = "IdentityManagerAPI",
                    ClientSecrets = new List<Secret>{
                        new Secret("secret".Sha256())
                    },
                    Claims = new List<System.Security.Claims.Claim>
                    {
                        new System.Security.Claims.Claim("name", "Identity Manager API"),
                        new System.Security.Claims.Claim("role", "IdentityManagerAdministrator")
                    },
                    Flow = Flows.ClientCredentials,
                    PrefixClientClaims = false,
                    AccessTokenType = AccessTokenType.Jwt
                }
            };
        }
    }
}