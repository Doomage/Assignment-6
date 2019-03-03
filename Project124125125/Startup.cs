using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Linq;
using System.Security.Claims;
using System.Web.Helpers;
using Project124125125.Models;

[assembly: OwinStartupAttribute(typeof(Project124125125.Startup))]

namespace Project124125125
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateManager();
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }

        public void CreateManager()
        {
            DatabaseContext db = new DatabaseContext();

            var user = db.Users.FirstOrDefault(x => x.Role == Roles.Manager);

            if (user == null)   
            {
                var Manager = new User();
                Manager.Username = "Manager";
                Manager.Password = "Manager";
                Manager.Role = Roles.Manager;

                db.Users.Add(Manager);
                db.SaveChanges();
            }
        }
    }
}