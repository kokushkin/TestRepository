using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace EssentialWCF
{
    public class ServiceAuthentication : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            if (userName != "TestName" || password != "TestPassword")
                throw new SecurityTokenValidationException("Unknown username or password");
        }
    }

}