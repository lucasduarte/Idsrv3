using IdentityServer3.Core;
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
                        new System.Security.Claims.Claim("role", "IdentityManagerAdministrator"),
                        new System.Security.Claims.Claim("role", "Admin")
                    },
                    AllowedScopes = new List<string>
                    {
                        "IdentityManager"
                    },
                    Flow = Flows.ClientCredentials,
                    PrefixClientClaims = false,
                    AccessTokenType = AccessTokenType.Jwt
                },
                new Client{
                    ClientId = "idmgr_client",
                    ClientName = "IdentityManager",
                    Enabled = true,
                    Flow = Flows.Implicit,
                    RequireConsent = false,
                    RedirectUris = new List<string>{
                        "https://localhost:44325",
                    },
                    PostLogoutRedirectUris = new List<string>{
                        "https://localhost:44325/admin"
                    },
                    IdentityProviderRestrictions = new List<string>(){IdentityServer3.Core.Constants.PrimaryAuthenticationType},
                    AllowedScopes = {
                        IdentityServer3.Core.Constants.StandardScopes.OpenId,
                        "idmgr"
                    }
                },
                new Client 
                {
                    ClientName = "AD Client",
                    ClientId = "ad_client",
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,
                    IdentityTokenLifetime = 300,
                    AccessTokenLifetime = 3600,
                    RequireConsent = true,

                    RedirectUris = new List<string>
                    {
                        "https://localhost:44326"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44326"
                    },
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    }
                },
            };
        }
    }
}