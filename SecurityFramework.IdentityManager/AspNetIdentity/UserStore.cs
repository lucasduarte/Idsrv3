using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityFramework.IdentityManager.AspNetIdentity
{
    public class UserStore : UserStore<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public UserStore(Context ctx)
            : base(ctx)
        {
        }
    }
}