using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace SecurityFramework.IdentityManager.Certificate
{
    public class Certificate
    {
        public static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\Certificate\idsrv3test.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}