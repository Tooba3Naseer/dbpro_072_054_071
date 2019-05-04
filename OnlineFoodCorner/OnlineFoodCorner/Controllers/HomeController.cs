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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using CrystalDecisions.ReportSource;


namespace OnlineFoodCorner.Controllers
{
    public class HomeController : Controller
    {
       
        public static int checker = 0;
        
        private DB24Entities db = new DB24Entities();

        public object MessageBox { get; private set; }

        public ActionResult Reportt1()
        {
            var c = db.ChefOrderDetails.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report1.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report1.pdf");

        }

        public ActionResult Reportt2()
        {
            var c = db.CustomerOrders.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report2.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report2.pdf");

        }

        public ActionResult Reportt3()
        {
            var c = db.CustomerOrderDetails.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report3.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report3.pdf");

        }

        public ActionResult Reportt4()
        {
            var c = db.CustomersFeedbacks.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report4.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report4.pdf");

        }

        public ActionResult Reportt5()
        {
            var c = db.DailyIncomes.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report5.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report5.pdf");

        }

        public ActionResult Reportt6()
        {
            var c = db.DesignationDetails.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report6.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report6.pdf");

        }

        public ActionResult Reportt7()
        {
            var c = db.EmployeeDetails.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report7.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report7.pdf");

        }

        public ActionResult Reportt8()
        {
            var c = db.MenuCardDetails.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report8.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report8.pdf");

        }

        public ActionResult Reportt9()
        {
            var c = db.PurchasedItemsDetails.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report9.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report9.pdf");

        }

        public ActionResult Reportt10()
        {
            var c = db.TotalPurchasedItems.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Report10.rpt"));

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf", "Report10.pdf");

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