using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace WebApi.TeacherFair
{
    public class MyAuthorizationServiceProvider:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        //Validate client authentication and create token
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if(context.UserName=="admin"&& context.Password=="admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Rohan Mane"));
                context.Validated(identity);
            }

            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Mayur Mane"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid Credentials");
                return;
            }

        }
    }
}