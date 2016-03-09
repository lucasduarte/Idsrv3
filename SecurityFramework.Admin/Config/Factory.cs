using IdentityAdmin.Configuration;
using IdentityServer3.Core.Configuration;
using IdentityServer3.EntityFramework;

namespace SecurityFramework.Admin.Config
{
    internal class Factory : IdentityAdminServiceFactory
    {
        public static IdentityServerServiceFactory Configure(string connString)
        {
            var efConfig = new EntityFrameworkServiceOptions
            {
                ConnectionString = connString,
            };
            var factory = new IdentityServerServiceFactory();
            //Clients
            //ConfigureClients(Clients.Get(), efConfig);
            //scopes
            //ConfigureScopes(Scopes.Get(), efConfig);
            factory.RegisterConfigurationServices(efConfig);
            factory.RegisterOperationalServices(efConfig);
            return factory;
        }
    }
}