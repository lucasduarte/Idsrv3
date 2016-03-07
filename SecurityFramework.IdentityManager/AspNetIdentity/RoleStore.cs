using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityFramework.IdentityManager.AspNetIdentity
{
    public class RoleStore : RoleStore<Role>
    {
        public RoleStore(Context ctx)
            : base(ctx)
        {
        }
    }
}