using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebApi.TeacherFair.Startup))]

namespace WebApi.TeacherFair
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Enabling cross origin request
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var MyProvider = new MyAuthorizationServiceProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                Provider = MyProvider,
        };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
