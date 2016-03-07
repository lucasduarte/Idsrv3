using IdentityServer3.AspNetIdentity;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using SecurityFramework.IdentityServer.AspNetIdentity;

namespace SecurityFramework.IdentityServer.Services
{
    public static class CustomUserServiceExtensions
    {
        public static void ConfigureCustomUserService(this IdentityServerServiceFactory factory, string connString)
        {
            factory.UserService = new Registration<IUserService, CustomUserService>();
            factory.Register(new Registration<UserManager>());
            factory.Register(new Registration<UserStore>());
            factory.Register(new Registration<Context>(resolver => new Context(connString)));
        }
    }

    public class CustomUserService : AspNetIdentityUserService<User, string>
    {
        public CustomUserService(UserManager userMgr)
            : base(userMgr)
        {
        }
    }
}