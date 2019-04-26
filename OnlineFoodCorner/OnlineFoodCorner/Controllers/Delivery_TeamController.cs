using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineFoodCorner;

namespace OnlineFoodCorner.Controllers
{
    public class Delivery_TeamController : Controller
    {
        private DB24Entities db = new DB24Entities();

        // GET: Delivery_Team
        public ActionResult ManageDeliveryTeam()
        {
            return View(db.Delivery_Teams.ToList());
        }

        // GET: Delivery_Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Delivery_Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Create_Date")] Delivery_Team delivery_Team)
        {
            if (ModelState.IsValid)
            {
                
                db.Delivery_Teams.Add(delivery_Team);
                db.SaveChanges();
                return RedirectToAction("ManageDeliveryTeam");
            }

            return View(delivery_Team);
        }

        // GET: Delivery_Team/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery_Team delivery_Team = db.Delivery_Teams.Find(id);
            if (delivery_Team == null)
            {
                return HttpNotFound();
            }
            return View(delivery_Team);
        }

        // POST: Delivery_Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Create_Date")] Delivery_Team delivery_Team)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(delivery_Team).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("ManageDeliveryTeam");
            }
            return View(delivery_Team);
        }

        // GET: Delivery_Team/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery_Team delivery_Team = db.Delivery_Teams.Find(id);
            if (delivery_Team == null)
            {
                return HttpNotFound();
            }
            return View(delivery_Team);
        }

        // POST: Delivery_Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery_Team delivery_Team = db.Delivery_Teams.Find(id);
            db.Delivery_Teams.Remove(delivery_Team);
            db.SaveChanges();
            return RedirectToAction("ManageDeliveryTeam");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
