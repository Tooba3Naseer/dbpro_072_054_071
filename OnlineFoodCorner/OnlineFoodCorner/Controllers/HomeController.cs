using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineFoodCorner;

namespace OnlineFoodCorner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CustomerIndex()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult indexAdmin()
        {
            return View();
        }

        public ActionResult ManageStock()
        {
            return View();
        }

        public ActionResult LogIn()
        {
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