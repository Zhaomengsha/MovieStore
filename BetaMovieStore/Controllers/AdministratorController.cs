using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BetaMovieStore.Data;
using BetaMovieStore.Models.Database;
using BetaMovieStore.Models.ViewModel;
using Microsoft.Ajax.Utilities;

namespace BetaMovieStore.Controllers
{
    public class AdministratorController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Administrator
        public ActionResult Index()
        {
            AdminVM obj = new AdminVM();
            obj.Customers = db.Customers.ToList();
            obj.Movies=db.Movies.ToList();
            var orderList = db.Orders.ToList();
            var orderRList = db.OrderRows.ToList();
            var orderDetail = orderList.GroupJoin(orderRList,
                                     o => o.Id,
                                     r => r.OrderId,
                                     (o, g) => new OrderDetailVM()
                                     {
                                         OrderOfCustomer = o,
                                         OrderRowsOfCustomer = g.OrderByDescending(or => or.Id).ToList()

                                     }).ToList();
          
            obj.OrderDetails =orderDetail;


            return View(obj);
        }

        //// GET: Administrator/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = db.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}

        // GET: Administrator/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateCustomers()
        {
            return View();
        }

        // POST: Administrator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Director,ReleaseYear,Genre,Price,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomers([Bind(Include = "FirstName,LastName,BillingAdress,BillingZip,BillingCity,DeliveryAdress,DeliveryZip,DeliveryCity,EmailAddress,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Administrator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Administrator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Director,ReleaseYear,Genre,Price,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        // GET: Customers/Edit/5
        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "Id,FirstName,LastName,BillingAdress,BillingZip,BillingCity,DeliveryAdress,DeliveryZip,DeliveryCity,EmailAddress,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }


        // GET: Administrator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Customers/Delete/5
        public ActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

        //public ActionResult OrderDetails()
        //{
        //    var orderList = db.Orders.ToList();
        //    var orderRList = db.OrderRows.ToList();
        //    var customList = db.Customers.ToList();
        //    var mList = db.Movies.ToList();

        //    var orderDetail = orderList.GroupJoin(orderRList,
        //                              o => o.Id,
        //                              r => r.OrderId,
        //                              (o, g) => new OrderDetailVM()
        //                              {
        //                                  OrderOfCustomer = o,
        //                                  OrderRowsOfCustomer = g.OrderByDescending(or => or.Id).ToList()

        //                              });
        //    .ToList();
        //    var orderDetail = orderRList.Join(orderList, or => or.OrderId),
        //    var orders = db.Orders.Include(o => o.Customer).ToList();


        //    return View(orderDetail);
        //}

    }
}

      

      
       
        
   