using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineFoodCorner;
using System.Threading.Tasks;

namespace OnlineFoodCorner.Controllers
{
	public class OrdersController : Controller
	{
		private DB24Entities db = new DB24Entities();

		// GET: Orders
		public async Task<ActionResult> OrdersIndex(string SearchString)
		{
			/*var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Orders_DeliveryTeams);
            return View(orders.ToList());*/
			var orders = from m in db.Orders
						 select m;

			if (!String.IsNullOrEmpty(SearchString))
			{
				orders = orders.Where(s => s.DeliveryStatus.Contains(SearchString));
			}

			return View(await orders.ToListAsync());
		}

		// GET: Orders/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Order order = db.Orders.Find(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}
		/*
        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Id");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo");
            ViewBag.OrderId = new SelectList(db.Orders_DeliveryTeams, "OrderId", "DeliveryStatus");
            ViewBag.OrderId = new SelectList(db.OrdersVehicles, "OrderId", "Status");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerId,EmployeeId,OrderDate,DeliveryDate,TotalBill,DeliveryAddress,BillingAddress,DeliveryArea,DeliveryCity")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Id", order.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", order.EmployeeId);
            ViewBag.OrderId = new SelectList(db.Orders_DeliveryTeams, "OrderId", "DeliveryStatus", order.OrderId);
            ViewBag.OrderId = new SelectList(db.OrdersVehicles, "OrderId", "Status", order.OrderId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Id", order.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", order.EmployeeId);
            ViewBag.OrderId = new SelectList(db.Orders_DeliveryTeams, "OrderId", "DeliveryStatus", order.OrderId);
            ViewBag.OrderId = new SelectList(db.OrdersVehicles, "OrderId", "Status", order.OrderId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId,EmployeeId,OrderDate,DeliveryDate,TotalBill,DeliveryAddress,BillingAddress,DeliveryArea,DeliveryCity")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Id", order.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", order.EmployeeId);
            ViewBag.OrderId = new SelectList(db.Orders_DeliveryTeams, "OrderId", "DeliveryStatus", order.OrderId);
            ViewBag.OrderId = new SelectList(db.OrdersVehicles, "OrderId", "Status", order.OrderId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
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
