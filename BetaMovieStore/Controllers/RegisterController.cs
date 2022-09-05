using BetaMovieStore.Data;
using BetaMovieStore.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetaMovieStore.Controllers
{

    public class RegisterController : Controller
    {
        private AppDbContext db = new AppDbContext();


        public ActionResult Index()
        {
            return View(new Customer());
        }

        [HttpPost]
        public ActionResult Index(string FirstName,string LastName, string BillingAdress, string BillingZip, string BillingCity, string DeliveryAdress, string DeliveryZip, string DeliveryCity,string EmailAddress,string Phone)
        {
            Customer customer = new Customer();
            customer.FirstName = FirstName;
            customer.LastName = LastName;
            customer.BillingAdress = BillingAdress;
            customer.BillingZip = BillingZip;
            customer.BillingCity = BillingCity;
            customer.DeliveryAdress = DeliveryAdress;
            customer.DeliveryZip = DeliveryZip;
            customer.DeliveryCity = DeliveryCity;
            customer.EmailAddress = EmailAddress;
            customer.Phone = Phone;
            this.db.Customers.Add(customer);
            this.db.SaveChanges();
            return RedirectToAction("Myorder","AddToCart");
        }
      
       
    }
}