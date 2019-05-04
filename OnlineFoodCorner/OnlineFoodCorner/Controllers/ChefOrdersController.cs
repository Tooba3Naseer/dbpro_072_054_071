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
    public class ChefOrdersController : Controller
    {
        private DB24Entities db = new DB24Entities();

        // GET: ChefOrders
        public ActionResult ChefOIndex()
        {
            var chefOrders = db.ChefOrders.Include(c => c.Employee).Include(c => c.Order);
            return View(chefOrders.ToList());
        }

        // GET: ChefOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChefOrder chefOrder = db.ChefOrders.Find(id);
            if (chefOrder == null)
            {
                return HttpNotFound();
            }
            return View(chefOrder);
        }

        // GET: ChefOrders/Create
        public ActionResult Create()
        {
            ViewBag.ChefId = new SelectList(db.Employees.Where(c => c.EmployeeTypeId == 2), "EmployeeId", "EmployeeRegNo");
            ViewBag.OrderId = new SelectList(db.Orders.Where(c => c.DeliveryStatus != "Delivered"), "OrderId", "OrderId");
            return View();
        }

        // POST: ChefOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,ChefId,AssignmentDate,Status")] ChefOrder chefOrder)
        {
            if (ModelState.IsValid)
            {
                chefOrder.Status = "Not Ready";
                db.ChefOrders.Add(chefOrder);
                db.SaveChanges();
                return RedirectToAction("ChefOIndex");
            }

            ViewBag.ChefId = new SelectList(db.Employees.Where(c => c.EmployeeTypeId == 2), "EmployeeId", "EmployeeRegNo", chefOrder.ChefId);
            ViewBag.OrderId = new SelectList(db.Orders.Where(c => c.DeliveryStatus != "Delivered"), "OrderId", "OrderId", chefOrder.OrderId);
            return View(chefOrder);
        }

        // GET: ChefOrders/Edit/5
        public ActionResult Edit(int? id, int?id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChefOrder chefOrder = db.ChefOrders.Find(id, id1);
            if (chefOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChefId = new SelectList(db.Employees.Where(c => c.EmployeeTypeId == 2), "EmployeeId", "EmployeeRegNo", chefOrder.ChefId);
            ViewBag.OrderId = new SelectList(db.Orders.Where(c => c.DeliveryStatus != "Delivered"), "OrderId", "DeliveryAddress", chefOrder.OrderId);
            return View(chefOrder);
        }

        // POST: ChefOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,ChefId,AssignmentDate,Status")] ChefOrder chefOrder)
        {
            if (ModelState.IsValid)
            {
                chefOrder.Status = "Not Ready";
                db.Entry(chefOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChefOIndex");
            }
            ViewBag.ChefId = new SelectList(db.Employees.Where(c => c.EmployeeTypeId == 2), "EmployeeId", "EmployeeRegNo", chefOrder.ChefId);
            ViewBag.OrderId = new SelectList(db.Orders.Where(c => c.DeliveryStatus != "Delivered"), "OrderId", "DeliveryAddress", chefOrder.OrderId);
            return View(chefOrder);
        }

        // GET: ChefOrders/Delete/5
        public ActionResult Delete(int? id, int? id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChefOrder chefOrder = db.ChefOrders.Find(id, id1);
            if (chefOrder == null)
            {
                return HttpNotFound();
            }
            return View(chefOrder);
        }

        // POST: ChefOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id1)
        {
            ChefOrder chefOrder = db.ChefOrders.Find(id, id1);
            db.ChefOrders.Remove(chefOrder);
            db.SaveChanges();
            return RedirectToAction("ChefOIndex");
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
