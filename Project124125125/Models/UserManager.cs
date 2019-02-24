using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Project124125125.Models
{
    public class UserManager
    {
        DatabaseContext db = new DatabaseContext();
       

        public User Login(User user)
        {
            var loggedInUser = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (loggedInUser != null)
            {
                var claims = new List<Claim>(new[]
                {
                    // adding following 2 claim just for supporting default antiforgery provider
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(
                        "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                    new Claim(ClaimTypes.Name, user.Username),
                    
                });
                foreach (var role in loggedInUser.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, user.Roles));
                }


                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.Current.GetOwinContext().Authentication.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, identity);
            }

            return loggedInUser;
        }

        public bool UserExists(string username)
        {
            return db.Users.Any(u => u.Username == username);
        }

        

    }
}