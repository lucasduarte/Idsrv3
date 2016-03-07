using Microsoft.AspNet.Identity;

namespace SecurityFramework.IdentityManager.AspNetIdentity
{
    public class RoleManager : RoleManager<Role>
    {
        public RoleManager(RoleStore store)
            : base(store)
        {
        }
    }
}