using Project124125125.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project124125125.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User loggedUser = Session["user"] as User;
            return View(loggedUser);
        }
        public ActionResult Complete()
        {
            User loggedUser = Session["user"] as User;
            loggedUser.Role += 1;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}