using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityFramework.IdentityServer.AspNetIdentity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}