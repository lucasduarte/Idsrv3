using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace SecurityFramework.IdentityServer.Services
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            var users = new List<InMemoryUser>
            {
                new InMemoryUser{Subject = "1", Username = "lucas.anicio", Password = "secret",
                    Claims = new Claim[]
                    {
                        //user claims goes here
                    }                   
                }
            };


            return users;
        }
    }
}