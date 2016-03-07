using Owin;
using SecurityFramework.IdentityServer.Configuration;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin.Security.Cookies;

namespace SecurityFramework.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies",
            });

            app.Map("/core", coreApp =>
            {
                var factory = Factory.Configure("IdentityServerConfig");
                //factory.ConfigureCustomUserService("AspId");

                var options = new IdentityServerOptions
                {
                    Factory = factory,
                    SigningCertificate = Certificate.Certificate.LoadCertificate(),
                    SiteName = "Framework de Segurança STS",
                    IssuerUri = "https://securityframework/core",
                    PublicOrigin = "https://localhost:44324",
                    AuthenticationOptions = new AuthenticationOptions
                    {
                        EnablePostSignOutAutoRedirect = true
                    },
                    CspOptions = new CspOptions()
                    {
                        Enabled = false
                    }
                };

                coreApp.UseIdentityServer(options);

            });
        }
    }
}