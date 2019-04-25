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
    public class FoodCategoriesController : Controller
    {
        private DB24Entities db = new DB24Entities();

        // GET: FoodCategories
        public ActionResult FoodCategories()
        {
            return View(db.FoodCategories.ToList());
        }

      
        // GET: FoodCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,Description")] FoodCategory foodCategory)
        {
            if (ModelState.IsValid)
            {
                db.FoodCategories.Add(foodCategory);
                db.SaveChanges();
                return RedirectToAction("FoodCategories");
            }

            return View(foodCategory);
        }

        // GET: FoodCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCategory foodCategory = db.FoodCategories.Find(id);
            if (foodCategory == null)
            {
                return HttpNotFound();
            }
            return View(foodCategory);
        }

        // POST: FoodCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,Description")] FoodCategory foodCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FoodCategories");
            }
            return View(foodCategory);
        }

        // GET: FoodCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCategory foodCategory = db.FoodCategories.Find(id);
            if (foodCategory == null)
            {
                return HttpNotFound();
            }
            return View(foodCategory);
        }

        // POST: FoodCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodCategory foodCategory = db.FoodCategories.Find(id);
            db.FoodCategories.Remove(foodCategory);
            db.SaveChanges();
            return RedirectToAction("FoodCategories");
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
