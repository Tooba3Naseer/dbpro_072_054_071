using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using OnlineFoodCorner;
using System.IO;

namespace OnlineFoodCorner.Controllers
{
    public class HomeController : Controller
    {
       
        public static int checker = 0;
        
        private DB24Entities db = new DB24Entities();

           public ActionResult CookIndex()
		{
			return View();
		}


		public ActionResult DelIndex()
		{
			return View();
		}

        public ActionResult CustomerIndex()
        {
            var menuCards = db.MenuCards.Include(m => m.FoodCategory);
            return View(menuCards.ToList());
        }
        public ActionResult cancel()
        {
            Order order = db.Orders.Find(UsersController.Orderid);
            OrderDetail od = db.OrderDetails.FirstOrDefault(u => u.OrderId == (UsersController.Orderid));
            while (od != null)
            {
                db.OrderDetails.Remove(od);
                db.SaveChanges();
                od = db.OrderDetails.FirstOrDefault(u => u.OrderId == (UsersController.Orderid));
            }
            db.Orders.Remove(order);
            db.SaveChanges();
            checker = 1;
            return RedirectToAction("CustomerIndex");
        }
        public ActionResult logOut()
        {
            Order order = db.Orders.Find(UsersController.Orderid);
            if (order != null)
            {
                
                if (order.TotalBill == null)
                {
                    OrderDetail od = db.OrderDetails.FirstOrDefault(u => u.OrderId == (UsersController.Orderid));
                    while (od != null)
                    {
                        db.OrderDetails.Remove(od);
                        db.SaveChanges();
                        od = db.OrderDetails.FirstOrDefault(u => u.OrderId == (UsersController.Orderid));
                    }
                    
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult add(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (checker == 1)
            {
                User user1 = db.Users.Find(UsersController.customerid);
                Order order = new Order();
                order.CustomerId = UsersController.customerid;
                order.OrderDate = DateTime.Now;
                order.DeliveryAddress = user1.Address;
                order.BillingAddress = user1.Address;
                order.DeliveryCity = user1.City;
                order.DeliveryStatus = "Info Received";
                order.BillingStatus = "Unpaid";
                db.Orders.Add(order);
                db.SaveChanges();
                UsersController.Orderid = order.OrderId;
                checker = 0;
            }
            MenuCard menuCard = db.MenuCards.Find(id);
            if (menuCard == null)
            {
                return HttpNotFound();
            }

           
            try
            {
                OrderDetail orderdetail = new OrderDetail();
                orderdetail.FoodId = menuCard.FoodId;
                orderdetail.OrderId = UsersController.Orderid;
                orderdetail.Quantity = 1;
                orderdetail.Discount = 0;
                orderdetail.Price = menuCard.UnitPrice;
                db.OrderDetails.Add(orderdetail);
                db.SaveChanges();
                return RedirectToAction("cart");
            }
            catch(Exception)
            {
                return View("Error");
            }
            
        }

        public ActionResult Proceed()
        {
            Order order = db.Orders.Find(UsersController.Orderid);
            var OrderDetails = db.OrderDetails.Include(m => m.MenuCard).Where(x => x.OrderId == UsersController.Orderid).ToList();
            decimal totalBill = 0;
            for (int i =0; i < OrderDetails.Count; i++)
            {
                totalBill = totalBill + Convert.ToDecimal(OrderDetails[i].Price);
            }
            order.TotalBill = totalBill;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Checkout");
        }

        public ActionResult Checkout()
        {
            OrderDetail OrderD = db.OrderDetails.FirstOrDefault(u => u.OrderId == (UsersController.Orderid)); ;
            Order order = db.Orders.Find(UsersController.Orderid);
            if (OrderD == null)
            {
                checker = 1;
                db.Orders.Remove(order);
                db.SaveChanges();
                return RedirectToAction("CustomerIndex");
            }
           
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout([Bind(Include = "OrderId, CustomerId, EmployeeId, OrderDate, DeliveryDate, TotalBill, DeliveryAddress, BillingAddress, DeliveryArea, DeliveryCity, DeliveryStatus, BillingStatus")] Order order)
        {
            Order order1 = db.Orders.Find(UsersController.Orderid);
            order1.DeliveryAddress = order.DeliveryAddress;
            order1.BillingAddress = order.BillingAddress;
            order1.DeliveryArea = order.DeliveryArea;
            order1.DeliveryCity = order.DeliveryCity;
            order1.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(order1).State = EntityState.Modified;
                db.SaveChanges();
                checker = 1;
                return RedirectToAction("OrderDetails");
            }
           
            return View(order);
        }

        public ActionResult cart()
        {
           
            
            var OrderDetails = db.OrderDetails.Include(m => m.MenuCard).Where(x => x.OrderId == UsersController.Orderid).ToList();
            
            return View(OrderDetails.ToList());
        }

        public ActionResult OrderDetails()
        {
            var Order = db.Orders.Where(x => x.CustomerId == UsersController.customerid).OrderByDescending(s => s.OrderId).ToList();

            return View(Order.ToList());
        }
        
        public ActionResult Delete(int? id1, int? id)
        {
            if (id == null || id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id1, id);
            return View(orderDetail);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id1, int id)
        {
            
            OrderDetail orderDetail = db.OrderDetails.Find(id1, id);
            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();
            
            return RedirectToAction("cart");
            
        }

        public ActionResult Edit(int? id1, int? id)
        {
            if (id == null || id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id1, id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            
            return View(orderDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetail orderDetail)
        {

            if (ModelState.IsValid)
            {
                MenuCard mm = db.MenuCards.Find(orderDetail.FoodId);
                orderDetail.Price = mm.UnitPrice * orderDetail.Quantity;
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("cart");
            }
            
            return View(orderDetail);
        }

        public ActionResult Index()
        {
            var menuCards = db.MenuCards.Include(m => m.FoodCategory);
            return View(menuCards.ToList());
        }

        public ActionResult indexAdmin()
        {
            return View();
        }

        public ActionResult Feedbacks()
        {

            return View(db.Feedbacks.ToList());
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}