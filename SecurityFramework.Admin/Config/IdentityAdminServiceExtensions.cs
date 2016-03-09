

using IdentityAdmin.Configuration;
using IdentityAdmin.Core;
using SecurityFramework.Admin.Config;

namespace SecurityFramework.Admin.Config
{
    public static class IdentityAdminServiceExtensions
    {
        public static void Configure(this IdentityAdminServiceFactory factory)
        {
            factory.IdentityAdminService = new Registration<IIdentityAdminService, IdentityAdminManagerService>();
        }
    }
}