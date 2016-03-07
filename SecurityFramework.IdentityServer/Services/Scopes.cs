using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                }
            };

            scopes.Add(StandardScopes.OpenId);
            scopes.Add(StandardScopes.Profile);
            scopes.Add(StandardScopes.OfflineAccess);
                     
            return scopes;
        }
    }
}