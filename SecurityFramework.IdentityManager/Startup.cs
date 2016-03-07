using IdentityManager.Configuration;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using SecurityFramework.IdentityManager.Services;
using Microsoft.Owin.Security.Jwt;

namespace SecurityFramework.IdentityManager
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies",
            });

            app.Map("/admin", adminApp =>
            {
                app.UseCors(CorsOptions.AllowAll);
                var factory = new IdentityManagerServiceFactory();

                factory.ConfigureSimpleIdentityManagerService("AspId");

                adminApp.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
                {
                    AllowedAudiences = new string[] { "https://localhost:44324/core/resources" },
                    AuthenticationType = "Jwt",
                    IssuerSecurityTokenProviders = new[] { 
                        new X509CertificateSecurityTokenProvider("https://localhost:44324/core", Certificate.Certificate.LoadCertificate())
                    },
                    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
                });

                var securityConfig = new ExternalBearerTokenConfiguration
                {
                    Audience = "https://localhost:44324/core/resources",
                    BearerAuthenticationType = "Jwt",
                    Issuer = "https://localhost:44324/core",
                    SigningCert = Certificate.Certificate.LoadCertificate(),
                    Scope = "IdentityManager",
                    RequireSsl = false,
                };

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory,
                    DisableUserInterface = true,
                    SecurityConfiguration = securityConfig
                });

            });
        }

    }
}