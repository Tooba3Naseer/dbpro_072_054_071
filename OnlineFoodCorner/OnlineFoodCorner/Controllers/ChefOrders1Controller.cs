using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineFoodCorner;

namespace OnlineFoodCorner.Controllers
{
	public class ChefOrders1Controller : Controller
	{
		private DB24Entities db = new DB24Entities();

		// GET: ChefOrders1
		public ActionResult TotalOrder()
		{
			var chefOrders = db.ChefOrders.Include(c => c.Employee).Include(c => c.Order).Where(x => x.ChefId == UsersController.employeeid).Where((o => o.Status.Contains("Ready")));
			return View(chefOrders.ToList());
		}


		public ActionResult ordertochef()
		{/*
			string query = "Select * From ChefOrder";
			IEnumerable<status> data = db.Database.SqlQuery<FtpStatusCode>(query);
			var conn = new SqlConnection(connectionStrings);
			return View(chefOrders.ToList());*/

			//SqlCommand cmd  = new SqlCommand("INSERT INTO  ChefOrder( OrderId, ChefId, AssignmentDate, STtaus) 
			//values('"+oid+"','"+ cid+"','"+ ad+"', '"+status+"'");

			//	ChefOrder ch = new ChefOrder();
	List<ChefOrder> chef = db.ChefOrders.ToList();
				List<Order> or = db.Orders.ToList();
				List<OrderDetail> orderdetails = db.OrderDetails.ToList();
				List<MenuCard> menu = db.MenuCards.ToList();


				var ord = from c in chef where (c.Status.Contains("Not Ready") && c.ChefId == UsersController.employeeid)
						  join o in or on c.OrderId equals o.OrderId into table1
						  from o in table1.ToList() 
						  join od in orderdetails on o.OrderId equals od.OrderId into table2
						  from od in table2.ToList()
						  join m in menu on od.FoodId equals m.FoodId into table3
						  from m in table3.ToList()

						  select new ViewModel
						  {
							  chef = c,
							  or = o,
							  orderdetails = od,
							  menu = m
						  };


			return View(ord);
			

		}


		// GET: ChefOrders1/Details/5
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


		// GET: ChefOrders1/Edit/5
		// GET: ChefOrders/Edit/5
		// GET: ChefOrders/Edit/5
		public ActionResult UpdateStatus(int? id, int? id1)
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
			ViewBag.ChefId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", chefOrder.ChefId);
			ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "DeliveryAddress", chefOrder.OrderId);
			return View(chefOrder);
		}

		// POST: ChefOrders/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult UpdateStatus([Bind(Include = "OrderId,ChefId,AssignmentDate,Status")] ChefOrder chefOrder)
		{
			if (ModelState.IsValid)
			{
				db.Entry(chefOrder).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("ordertochef");
			}
			ViewBag.ChefId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", chefOrder.ChefId);
			ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "DeliveryAddress", chefOrder.OrderId);
			return View(chefOrder);
		}

		// GET: ChefOrders1/Delete/5
		public ActionResult Delete(int? id)
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

		// POST: ChefOrders1/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			ChefOrder chefOrder = db.ChefOrders.Find(id);
			db.ChefOrders.Remove(chefOrder);
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


