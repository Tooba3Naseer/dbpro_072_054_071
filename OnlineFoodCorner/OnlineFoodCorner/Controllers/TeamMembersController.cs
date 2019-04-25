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
    public class TeamMembersController : Controller
    {
        private DB24Entities db = new DB24Entities();

        // GET: TeamMembers
        public ActionResult ManageTeam()
        {
            var teamMembers = db.TeamMembers.Include(t => t.Delivery_Team).Include(t => t.Employee);
            return View(teamMembers.ToList());
        }

        // GET: TeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Delivery_Teams, "Id", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo");
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,EmployeeId,Status,AssignmentDate")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                teamMember.AssignmentDate = DateTime.Now;
                db.TeamMembers.Add(teamMember);
                db.SaveChanges();
                return RedirectToAction("ManageTeam");
            }

            ViewBag.TeamId = new SelectList(db.Delivery_Teams, "Id", "Name", teamMember.TeamId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", teamMember.EmployeeId);
            return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public ActionResult Edit(int? id, int? id1)
        {
            if (id == null || id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id,id1);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Delivery_Teams, "Id", "Name", teamMember.TeamId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", teamMember.EmployeeId);
            return View(teamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,EmployeeId,Status,AssignmentDate")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                teamMember.AssignmentDate = DateTime.Now;
                db.Entry(teamMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageTeam");
            }
            ViewBag.TeamId = new SelectList(db.Delivery_Teams, "Id", "Name", teamMember.TeamId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", teamMember.EmployeeId);
            return View(teamMember);
        }

        // GET: TeamMembers/Delete/5
        public ActionResult Delete(int? id, int? id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id, id1);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id1)
        {
            TeamMember teamMember = db.TeamMembers.Find(id,id1);
            db.TeamMembers.Remove(teamMember);
            db.SaveChanges();
            return RedirectToAction("ManageTeam");
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
