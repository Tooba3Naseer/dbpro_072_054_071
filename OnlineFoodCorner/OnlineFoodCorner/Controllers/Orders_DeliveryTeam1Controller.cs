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
	public class Orders_DeliveryTeam1Controller : Controller
	{
		private DB24Entities db = new DB24Entities();
		public static int idOrder = 0;
		// GET: Orders_DeliveryTeam1
		public ActionResult ordertodeliver()
		{
			TeamMember tm = db.TeamMembers.FirstOrDefault(u => u.EmployeeId == (UsersController.employeeid));
			int id = tm.TeamId;
			var orders_DeliveryTeams = db.Orders_DeliveryTeams.Include(o => o.Delivery_Team).Where(o => o.Order.DeliveryStatus.Contains("In Transit")).Where(o => o.DeliveryTeamId == id);

			return View(orders_DeliveryTeams.ToList());
		}


		public ActionResult deliveredorder()
		{
			TeamMember tm = db.TeamMembers.FirstOrDefault(u => u.EmployeeId == (UsersController.employeeid));
			int id = tm.TeamId;
			var orders_DeliveryTeams = db.Orders_DeliveryTeams.Include(o => o.Delivery_Team).Where(o => o.Order.DeliveryStatus.Contains("Delivered")).Where(o => o.DeliveryTeamId == id);
			return View(orders_DeliveryTeams.ToList());
		}

		// GET: Orders_DeliveryTeam1/Details/5
		public ActionResult Details(int? id)
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

		// GET: Orders_DeliveryTeam1/Create
		public ActionResult Create()
		{
			ViewBag.DeliveryTeamId = new SelectList(db.Delivery_Teams, "Id", "Name");
			ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
			return View();
		}

		// POST: Orders_DeliveryTeam1/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "OrderId,DeliveryTeamId,AssignmentDate")] Orders_DeliveryTeam orders_DeliveryTeam)
		{
			if (ModelState.IsValid)
			{
				db.Orders_DeliveryTeams.Add(orders_DeliveryTeam);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.DeliveryTeamId = new SelectList(db.Delivery_Teams, "Id", "Name", orders_DeliveryTeam.DeliveryTeamId);
			ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "DeliveryAddress", orders_DeliveryTeam.OrderId);
			return View(orders_DeliveryTeam);
		}

		// GET: Orders/Edit/5
		public ActionResult UpdateStatus(int? id)
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
			idOrder = order.OrderId;
			return View(order);
		}

		// POST: Orders/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult UpdateStatus(Order order)
		{
			Order order1 = db.Orders.Find(idOrder);
			order1.DeliveryDate = DateTime.Now;
			order1.DeliveryStatus = order.DeliveryStatus;
			order1.BillingStatus = order.BillingStatus;
			if (ModelState.IsValid)
			{
				db.Entry(order1).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("deliveredorder");
			}
			return View(order1);
		}


		// GET: Orders_DeliveryTeam1/Delete/5
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

		// POST: Orders_DeliveryTeam1/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Orders_DeliveryTeam orders_DeliveryTeam = db.Orders_DeliveryTeams.Find(id);
			db.Orders_DeliveryTeams.Remove(orders_DeliveryTeam);
			db.SaveChanges();
			return RedirectToAction("Index");
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
