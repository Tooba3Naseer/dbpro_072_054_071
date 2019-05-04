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
	public class Orders_DeliveryTeamController : Controller
	{
		private DB24Entities db = new DB24Entities();

		// GET: Orders_DeliveryTeam
		public ActionResult OrdersDeliveryTeam()
		{
			var orders_DeliveryTeams = db.Orders_DeliveryTeams.Include(o => o.Delivery_Team).Include(o => o.Order);
			return View(orders_DeliveryTeams.ToList());
		}



		// GET: Orders_DeliveryTeam/Create
		public ActionResult Create()
		{
			ViewBag.DeliveryTeamId = new SelectList(db.Delivery_Teams, "Id", "Name");
			ViewBag.OrderId = new SelectList(db.Orders.Where(c => c.DeliveryStatus != "Delivered"), "OrderId", "OrderId");
			return View();
		}

		// POST: Orders_DeliveryTeam/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "OrderId,DeliveryTeamId,AssignmentDate")] Orders_DeliveryTeam orders_DeliveryTeam)
		{

			if (ModelState.IsValid)
			{
				Order order1 = db.Orders.Find(orders_DeliveryTeam.OrderId);
				order1.DeliveryStatus = "In Transit";
				orders_DeliveryTeam.AssignmentDate = DateTime.Now;
				db.Entry(order1).State = EntityState.Modified;
				db.SaveChanges();
				db.Orders_DeliveryTeams.Add(orders_DeliveryTeam);
				db.SaveChanges();
				return RedirectToAction("OrdersDeliveryTeam");
			}

			ViewBag.DeliveryTeamId = new SelectList(db.Delivery_Teams, "Id", "Name", orders_DeliveryTeam.DeliveryTeamId);
			ViewBag.OrderId = new SelectList(db.Orders.Where(c => c.DeliveryStatus != "Delivered"), "OrderId", "OrderId", orders_DeliveryTeam.OrderId);
			return View(orders_DeliveryTeam);
		}

		// GET: Orders_DeliveryTeam/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Orders_DeliveryTeam orders_DeliveryTeam = db.Orders_DeliveryTeams.Find(id);
			if (orders_DeliveryTeam == null)
			{
				return HttpNotFound();
			}
			ViewBag.DeliveryTeamId = new SelectList(db.Delivery_Teams, "Id", "Name", orders_DeliveryTeam.DeliveryTeamId);
			ViewBag.OrderId = new SelectList(db.Orders.Where(c => c.DeliveryStatus != "Delivered"), "OrderId", "DeliveryAddress", orders_DeliveryTeam.OrderId);
			return View(orders_DeliveryTeam);
		}

		// POST: Orders_DeliveryTeam/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "OrderId,DeliveryTeamId,AssignmentDate")] Orders_DeliveryTeam orders_DeliveryTeam)
		{
			if (ModelState.IsValid)
			{
				orders_DeliveryTeam.AssignmentDate = DateTime.Now;
				db.Entry(orders_DeliveryTeam).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("OrdersDeliveryTeam");
			}
			ViewBag.DeliveryTeamId = new SelectList(db.Delivery_Teams, "Id", "Name", orders_DeliveryTeam.DeliveryTeamId);
			ViewBag.OrderId = new SelectList(db.Orders.Where(c => c.DeliveryStatus != "Delivered"), "OrderId", "DeliveryAddress", orders_DeliveryTeam.OrderId);
			return View(orders_DeliveryTeam);
		}

		// GET: Orders_DeliveryTeam/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Orders_DeliveryTeam orders_DeliveryTeam = db.Orders_DeliveryTeams.Find(id);
			if (orders_DeliveryTeam == null)
			{
				return HttpNotFound();
			}
			return View(orders_DeliveryTeam);
		}

		// POST: Orders_DeliveryTeam/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Order order1 = db.Orders.Find(id);
			string str = "Info Received";
			order1.DeliveryStatus = str;
			db.Entry(order1).State = EntityState.Modified;
			db.SaveChanges();
			Orders_DeliveryTeam orders_DeliveryTeam = db.Orders_DeliveryTeams.Find(id);
			db.Orders_DeliveryTeams.Remove(orders_DeliveryTeam);
			db.SaveChanges();
			return RedirectToAction("OrdersDeliveryTeam");
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
