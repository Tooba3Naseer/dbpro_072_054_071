using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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

        
        public ActionResult feedback()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult feedback([Bind(Include = "Id,comment,CustomerId")]Feedback fb)
        {
            int id = UsersController.customerid;
            fb.CustomerId = id;
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(fb);
                db.SaveChanges();
                return RedirectToAction("CustomerIndex");
            }
            return View(fb);
            
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