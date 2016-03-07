using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityFramework.IdentityServer.AspNetIdentity
{
    public class UserStore : UserStore<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public UserStore(Context ctx)
            : base(ctx)
        {
        }
    }
}