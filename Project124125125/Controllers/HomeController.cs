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
    }
}