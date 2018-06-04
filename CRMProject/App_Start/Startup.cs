using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using CRMProject.BLL.Services;
using Microsoft.AspNet.Identity;
using CRMProject.BLL.Interfaces;

[assembly: OwinStartup(typeof(CRMProject.App_Start.Startup))]

namespace CRMProject.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // TODO: maybe add role manager and user manager
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}