using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityFramework.IdentityManager.AspNetIdentity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}