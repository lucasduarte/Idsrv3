using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityFramework.IdentityManager.AspNetIdentity
{
    public class Context : IdentityDbContext<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public Context(string connString)
            : base(connString)
        {
        }
    }
}