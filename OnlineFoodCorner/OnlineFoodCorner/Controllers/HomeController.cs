using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using OnlineFoodCorner;

namespace OnlineFoodCorner.Controllers
{
    public class HomeController : Controller
    {
        private DB24Entities db = new DB24Entities();
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