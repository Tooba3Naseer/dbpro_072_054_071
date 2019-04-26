using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineFoodCorner;
using System.IO;

namespace OnlineFoodCorner.Controllers
{
    public class MenuCardsController : Controller
    {
        private DB24Entities db = new DB24Entities();

        // GET: MenuCards
        public ActionResult MenuItems()
        {
            var menuCards = db.MenuCards.Include(m => m.FoodCategory);
            return View(menuCards.ToList());
        }

        // GET: MenuCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCard menuCard = db.MenuCards.Find(id);
            if (menuCard == null)
            {
                return HttpNotFound();
            }
            return View(menuCard);
        }

        // GET: MenuCards/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.FoodCategories, "Id", "CategoryName");
            return View();
        }

        // POST: MenuCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( MenuCard menuCard)
        {
            string filename = Path.GetFileNameWithoutExtension(menuCard.ImageFile.FileName);
            string extension = Path.GetExtension(menuCard.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            menuCard.ImagePath = "~/assets/images/" + filename;
            filename = Path.Combine(Server.MapPath("~/assets/images/"), filename);
            menuCard.ImageFile.SaveAs(filename);
            if (ModelState.IsValid)
            {
                db.MenuCards.Add(menuCard);
                db.SaveChanges();
                return RedirectToAction("MenuItems");
            }

            ViewBag.CategoryId = new SelectList(db.FoodCategories, "Id", "CategoryName", menuCard.CategoryId);
            return View(menuCard);
        }

        // GET: MenuCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCard menuCard = db.MenuCards.Find(id);
            if (menuCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.FoodCategories, "Id", "CategoryName", menuCard.CategoryId);
            return View(menuCard);
        }

        // POST: MenuCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodId,Name,Description,QuantityPerUnit,UnitPrice,ImagePath,CategoryId")] MenuCard menuCard)
        {

            if (ModelState.IsValid)
            {
                db.Entry(menuCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MenuItems");
            }
            ViewBag.CategoryId = new SelectList(db.FoodCategories, "Id", "CategoryName", menuCard.CategoryId);
            return View(menuCard);
        }

        // GET: MenuCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCard menuCard = db.MenuCards.Find(id);
            if (menuCard == null)
            {
                return HttpNotFound();
            }
            return View(menuCard);
        }

        // POST: MenuCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuCard menuCard = db.MenuCards.Find(id);
            db.MenuCards.Remove(menuCard);
            db.SaveChanges();
            return RedirectToAction("MenuItems");
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
