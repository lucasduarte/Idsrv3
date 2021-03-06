﻿using IdentityManager.Configuration;
using Owin;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using SecurityFramework.IdentityManager.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityManager.Extensions;
using IdentityManager.Core.Logging;
using IdentityManager.Logging;
using IdentityManager;

namespace SecurityFramework.IdentityManager
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            LogProvider.SetCurrentLogProvider(new TraceSourceLogProvider());

            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies",
            });
            

            app.UseOpenIdConnectAuthentication(new Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "oidc",
                Authority = "https://localhost:44324/core",
                ClientId = "idmgr_client",
                RedirectUri = "https://localhost:44325",
                ResponseType = "id_token",
                UseTokenLifetime = false,
                Scope = "openid idmgr",
                SignInAsAuthenticationType = "Cookies",
                Notifications = new Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = n =>
                    {
                        n.AuthenticationTicket.Identity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                        return Task.FromResult(0);
                    },
                    RedirectToIdentityProvider = async n =>
                    {
                        if (n.ProtocolMessage.RequestType == Microsoft.IdentityModel.Protocols.OpenIdConnectRequestType.LogoutRequest)
                        {
                            var result = await n.OwinContext.Authentication.AuthenticateAsync("Cookies");
                            if (result != null)
                            {
                                var id_token = result.Identity.Claims.GetValue("id_token");
                                if (id_token != null)
                                {
                                    n.ProtocolMessage.IdTokenHint = id_token;
                                    n.ProtocolMessage.PostLogoutRedirectUri = "https://localhost:44325/admin";
                                }
                            }
                        }
                    }
                }
            });
            

            app.Map("/admin", adminApp =>
            {
              
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureSimpleIdentityManagerService("AspId");

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory,
                   // DisableUserInterface = true,
                    SecurityConfiguration = new HostSecurityConfiguration
                    {
                        HostAuthenticationType = Constants.CookieAuthenticationType,
                        AdditionalSignOutType = "oidc",
                        AdminRoleName = "Admin",
                        
                    }
                });

            });
        }

    }
}