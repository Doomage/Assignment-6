using Microsoft.AspNet.Identity;
using Project124125125.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project124125125.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Wait()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string Username,string Password)
        {
            UserManager manager = new UserManager();
            var loggedInUser = manager.Login(Username,Password);

            if (loggedInUser != null && loggedInUser.Accepted == true)
            {
                Session["user"] = loggedInUser;
                return RedirectToAction("index", "home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
