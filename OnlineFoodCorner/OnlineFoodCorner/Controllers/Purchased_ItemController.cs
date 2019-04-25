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
    public class Purchased_ItemController : Controller
    {
        private DB24Entities db = new DB24Entities();

        // GET: Purchased_Item
        public ActionResult PurchasedItems()
        {
            var purchased_Items = db.Purchased_Items.Include(p => p.Supplier).Include(p => p.Category);
            return View(purchased_Items.ToList());
        }

        // GET: Purchased_Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchased_Item purchased_Item = db.Purchased_Items.Find(id);
            if (purchased_Item == null)
            {
                return HttpNotFound();
            }
            return View(purchased_Item);
        }

        // GET: Purchased_Item/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Purchased_Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SupplierId,CategoryId,QuantityPerUnit,UnitsInStock,UnitPrice")] Purchased_Item purchased_Item)
        {
            if (ModelState.IsValid)
            {
                db.Purchased_Items.Add(purchased_Item);
                db.SaveChanges();
                return RedirectToAction("PurchasedItems");
            }

            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", purchased_Item.SupplierId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", purchased_Item.CategoryId);
            return View(purchased_Item);
        }

        // GET: Purchased_Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchased_Item purchased_Item = db.Purchased_Items.Find(id);
            if (purchased_Item == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", purchased_Item.SupplierId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", purchased_Item.CategoryId);
            return View(purchased_Item);
        }

        // POST: Purchased_Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SupplierId,CategoryId,QuantityPerUnit,UnitsInStock,UnitPrice")] Purchased_Item purchased_Item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchased_Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PurchasedItems");
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", purchased_Item.SupplierId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", purchased_Item.CategoryId);
            return View(purchased_Item);
        }

        // GET: Purchased_Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchased_Item purchased_Item = db.Purchased_Items.Find(id);
            if (purchased_Item == null)
            {
                return HttpNotFound();
            }
            return View(purchased_Item);
        }

        // POST: Purchased_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchased_Item purchased_Item = db.Purchased_Items.Find(id);
            db.Purchased_Items.Remove(purchased_Item);
            db.SaveChanges();
            return RedirectToAction("PurchasedItems");
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
