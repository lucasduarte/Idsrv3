using Microsoft.AspNet.Identity;

namespace SecurityFramework.IdentityServer.AspNetIdentity
{
    public class RoleManager : RoleManager<Role>
    {
        public RoleManager(RoleStore store)
            : base(store)
        {
        }
    }
}