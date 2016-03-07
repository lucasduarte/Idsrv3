using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SecurityFramework.IdentityServer.Services
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
            {
                new Scope
                {
                    Enabled = true,
                    Name = "roles",
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                },
                new Scope
                {
                    Enabled = true,
                    Name = "IdentityManager",
                    Emphasize = true,
                    Description = "Access to a Identity Manager application",
                    Type = ScopeType.Resource,

                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(ClaimTypes.Name),
                        new ScopeClaim(ClaimTypes.Role)
                    }
                }
            };

            scopes.Add(StandardScopes.OpenId);
            scopes.Add(StandardScopes.Profile);
            scopes.Add(StandardScopes.OfflineAccess);
                     
            return scopes;
        }
    }
}