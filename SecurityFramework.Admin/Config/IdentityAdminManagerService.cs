using IdentityServer3.Admin.EntityFramework;
using IdentityServer3.Admin.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityFramework.Admin.Config
{
    public class IdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public IdentityAdminManagerService()
            : base("IdentityServerConfig")
        {

        }
    }
}