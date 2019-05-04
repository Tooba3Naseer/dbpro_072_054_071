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
	public class EmployeesController : Controller
	{
		private DB24Entities db = new DB24Entities();

		// GET: Employees
		public ActionResult ManageEmployees()
		{
			var employees = db.Employees.Include(e => e.EmployeeType).Include(e => e.User).Include(e => e.Designation);
			return View(employees.ToList());
		}

		// GET: Employees/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return View(employee);
		}

		// GET: Employees/Create
		public ActionResult Create()
		{
			ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes.Where(c => c.Id != 1), "Id", "Type");
			ViewBag.EmployeeId = new SelectList(db.Users, "Id", "FirstName");
			ViewBag.DesignationId = new SelectList(db.Designations.Where(c => c.Id != 1), "Id", "designationOfEmployee");
			return View();
		}

		// POST: Employees/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "EmployeeId,EmployeeRegNo,HireDate,DesignationId,EmployeeTypeId")] Employee employee, [Bind(Include = "Id,FirstName,LastName,Email,Contact,Password,Address,City")] User user)
		{
			if (ModelState.IsValid)
			{
				db.Users.Add(user);
				employee.EmployeeId = user.Id;
				db.Employees.Add(employee);
				db.SaveChanges();
				return RedirectToAction("ManageEmployees");
			}

			ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes.Where(c => c.Id != 1), "Id", "Type", employee.EmployeeTypeId);
			ViewBag.EmployeeId = new SelectList(db.Users, "Id", "FirstName", employee.EmployeeId);
			ViewBag.DesignationId = new SelectList(db.Designations.Where(c => c.Id != 1), "Id", "designationOfEmployee", employee.DesignationId);
			return View(employee);
		}

		// GET: Employees/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes.Where(c => c.Id != 1), "Id", "Type", employee.EmployeeTypeId);
			ViewBag.EmployeeId = new SelectList(db.Users, "Id", "FirstName", employee.EmployeeId);
			ViewBag.DesignationId = new SelectList(db.Designations.Where(c => c.Id != 1), "Id", "designationOfEmployee", employee.DesignationId);
			return View(employee);
		}

		// POST: Employees/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeRegNo,HireDate,DesignationId,EmployeeTypeId")] Employee employee, [Bind(Include = "Id,FirstName,LastName,Email,Contact,Password,Address,City")] User user)
		{
			if (ModelState.IsValid)
			{
				db.Entry(user).State = EntityState.Modified;
				//employee.EmployeeId = user.Id;
				db.Entry(employee).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("ManageEmployees");
			}
			ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes.Where(c => c.Id != 1), "Id", "Type", employee.EmployeeTypeId);
			ViewBag.EmployeeId = new SelectList(db.Users, "Id", "FirstName", employee.EmployeeId);
			ViewBag.DesignationId = new SelectList(db.Designations.Where(c => c.Id != 1), "Id", "designationOfEmployee", employee.DesignationId);
			return View(employee);
		}

		// GET: Employees/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return View(employee);
		}

		// POST: Employees/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Employee employee = db.Employees.Find(id);
			User user = db.Users.Find(id);
			db.Employees.Remove(employee);
			db.Users.Remove(user);
			db.SaveChanges();
			return RedirectToAction("ManageEmployees");
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
