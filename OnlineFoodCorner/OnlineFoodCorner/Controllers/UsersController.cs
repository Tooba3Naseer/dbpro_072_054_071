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
    public class UsersController : Controller
    {
        public static int customerid = 0;
		public static int employeeid = 0;
		private DB24Entities db = new DB24Entities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Customer).Include(u => u.Employee);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult MyProfile()
        {
            int id = UsersController.customerid;

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
            ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyProfile([Bind(Include = "Id,FirstName,LastName,Email,Contact,Password,Address,City")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomerIndex", "Home");
            }
            ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
            ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
            return View(user);

        }

        public ActionResult feedback()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult feedback([Bind(Include = "Id,comment,CustomerId")]Feedback fb)
        {
            int id = UsersController.customerid;
            fb.CustomerId = id;
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(fb);
                db.SaveChanges();
                return RedirectToAction("CustomerIndex", "Home");
            }
            return View(fb);

        }

        public ActionResult OthersFeedback()
        {
  
            return View(db.Feedbacks.ToList());
        }

        // GET: Users/Create
        public ActionResult SignUpC()
        {
            ViewBag.Id = new SelectList(db.Customers, "Id", "Id");
            ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo");
            return View();
        }

        public ActionResult SignUpEmp()
        {
            ViewBag.Id = new SelectList(db.Customers, "Id", "Id");
            ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo");
            return View();
        }

        public ActionResult LogIn()
        {
            
            return View();
        }


        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpC([Bind(Include = "Id,FirstName,LastName,Email,Contact,Password,Address,City")] User user, [Bind(Include = "Id,RegistrationDate")] Customer customer)
        {
            User user1 = db.Users.FirstOrDefault(u => u.Email == (user.Email));
            if (user1 != null)
                ModelState.AddModelError("Email", "This Email was already taken");
            else
            {
                if (ModelState.IsValid)
                {
                    
                    db.Users.Add(user);
                    db.SaveChanges();
                    customer.Id = user.Id;
                    customerid = customer.Id;
                    customer.RegistrationDate = DateTime.Now;
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    Order order = new Order();
                    order.CustomerId = customerid;
                    order.OrderDate = DateTime.Now;
                    order.DeliveryAddress = user.Address;
                    order.BillingAddress = user.Address;
                    order.DeliveryCity = user.City;
                    order.DeliveryStatus = "Info Received";
                    order.BillingStatus = "Unpaid";
                    db.Orders.Add(order);
                    db.SaveChanges();
                    Orderid = order.OrderId;
                    return RedirectToAction("CustomerIndex", "Home");
                }

                ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
                ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
            }
            return View(user);
        }


        
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User user)
        {

            //fetche the data of user on the basis of inserted email
            User user1 = db.Users.FirstOrDefault(u => u.Email == (user.Email));
            //if entered email is not bound to any user then object will be null
            if (user1 == null)
                {
                    TempData["ErrorMSG"] = "object not found";
                    return View(user);

                }
                //if we are here then it mean we sucsessfuly retrived the data
                //now we compare password
                
                if (user1.Password != user.Password)
                {
                    TempData["ErrorMSG"] = "Password not matched";
                    return View(user);

                }

                if (user1 != null)
                {


                    if (user1.Password == user.Password)
                    {

                    Customer customer = db.Customers.FirstOrDefault(u => u.Id == (user1.Id));
                    if (customer != null)
                    {
                        
                        customerid = customer.Id;
                        Order order = new Order();
                        order.CustomerId = customerid;
                        order.OrderDate = DateTime.Now;
                        order.DeliveryAddress = user1.Address;
                        order.BillingAddress = user1.Address;
                        order.DeliveryCity = user1.City;
                        order.DeliveryStatus = "Info Received";
                        order.BillingStatus = "Unpaid";
                        db.Orders.Add(order);
                        db.SaveChanges();
                        Orderid = order.OrderId;
                        return RedirectToAction("CustomerIndex", "Home"); }
                    Employee emp = db.Employees.FirstOrDefault(u => u.EmployeeId == (user1.Id));
                    if (emp != null)
                        {
                            EmployeeType type = db.EmployeeTypes.FirstOrDefault(u => u.Type == "Admin");
                            EmployeeType type1 = db.EmployeeTypes.FirstOrDefault(u => u.Type == "Deliverer");
                            EmployeeType type2 = db.EmployeeTypes.FirstOrDefault(u => u.Type == "Chef");
                        if(type.Id == emp.EmployeeTypeId)
                        {
                            return RedirectToAction("indexAdmin", "Home");
                        }
                        if (type1.Id == emp.EmployeeTypeId)
                        {
                            return RedirectToAction("indexAdmin", "Home");
                        }
                        if (type2.Id == emp.EmployeeTypeId)
                        {
                            return RedirectToAction("indexAdmin", "Home");
                        }

                    }
                        
                    }
                    return View();
                }
                return View();
            
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpEmp([Bind(Include = "Id,FirstName,LastName,Email,Contact,Password,Address,City")] User user, [Bind(Include = "EmployeeId,EmployeeRegNo,HireDate,DesignationId,EmployeeTypeId")] Employee emp)
        {
            
                User user1 = db.Users.FirstOrDefault(u => u.Email == (user.Email));

                if (user1 != null)
                    ModelState.AddModelError("Email", "This Email was already taken");
                else
                {
                    if (ModelState.IsValid)
                    {
                        Designation des = db.Designations.FirstOrDefault(u => u.designationOfEmployee == "Manager");
                        emp.DesignationId = des.Id;
                        EmployeeType empType = db.EmployeeTypes.FirstOrDefault(u => u.Type == "Admin");
                        emp.EmployeeTypeId = empType.Id;
                        db.Users.Add(user);
                        db.Employees.Add(emp);
                        db.SaveChanges();
                        return RedirectToAction("indexAdmin", "Home");
                    }

                    ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
                    ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
                }
                return RedirectToAction("SignUpEmp");
            
            
        }



		public ActionResult MyChefProfile()
		{
			int id = UsersController.employeeid;

			User user = db.Users.Find(id);
			if (user == null)
			{
				return HttpNotFound();
			}
			ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
			ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
			return View(user);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MyChefProfile([Bind(Include = "Id,FirstName,LastName,Email,Contact,Password,Address,City")] User user)
		{
			if (ModelState.IsValid)
			{
				db.Entry(user).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("CookIndex", "Home");
			}
			ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
			ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
			return View(user);

		}



		public ActionResult MyDelProfile()
		{
			int id = UsersController.employeeid;

			User user = db.Users.Find(id);
			if (user == null)
			{
				return HttpNotFound();
			}
			ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
			ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
			return View(user);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MyDelProfile([Bind(Include = "Id,FirstName,LastName,Email,Contact,Password,Address,City")] User user)
		{
			if (ModelState.IsValid)
			{
				db.Entry(user).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("CookIndex", "Home");
			}
			ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
			ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
			return View(user);

		}


		// GET: Users/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
            ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Contact,Password,Address,City")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Customers, "Id", "Id", user.Id);
            ViewBag.Id = new SelectList(db.Employees, "EmployeeId", "EmployeeRegNo", user.Id);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
