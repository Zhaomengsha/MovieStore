using BetaMovieStore.Data;
using BetaMovieStore.Models.Database;
using BetaMovieStore.Models.ViewModel;
using BetaMovieStore.ViewModel;
using BetaMovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BetaMovieStore.Controllers
{
    public class AddToCartController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public static bool newCustomer = false;


        // GET: AddToCart
        public ActionResult Add(Movie m)
        {

            if (Session["cart"] == null)
            {
                List<Movie> listMovie = new List<Movie>();

                listMovie.Add(m);
                Session["cart"] = listMovie;
                ViewBag.cart = listMovie.Count();


                Session["count"] = 1;


            }
            else
            {
                List<Movie> listMovie = (List<Movie>)Session["cart"];
                listMovie.Add(m);
                Session["cart"] = listMovie;
                ViewBag.cart = listMovie.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return RedirectToAction("Index", "Movie");



        }
        public ActionResult Myorder()

        {
            var listMovie = (List<Movie>)Session["cart"];
            if (Session["cart"] == null)
            {
                IOrderedEnumerable<CartVM> query = Enumerable.Empty<CartVM>().OrderBy(x => 1); ;
                return View(query);

            }
            else
            {
                var query = (from m in listMovie
                             group m by m.Id
                         into g
                             select new CartVM
                             {
                                 Id = g.Key,
                                 Title = g.FirstOrDefault().Title,
                                 Image = g.FirstOrDefault().Image,
                                 Price = g.FirstOrDefault().Price,
                                 Quantity = g.Count()
                             })
                         .OrderBy(g => g.Title);
                return View(query);
            }
           
            

        }
        
        public ActionResult IncreaseBt(Movie obj)
        {
            var listMovie = (List<Movie>)Session["cart"];
            int index = listMovie.FindIndex(x => x.Id == obj.Id);
            listMovie.Add(listMovie[index]);
            Session["cart"]=listMovie;
            Session["count"] = listMovie.Count();
            return RedirectToAction("Myorder","AddToCart");
        }


        public ActionResult DecreaseBt(Movie obj)
        {
            var listMovie = (List<Movie>)Session["cart"];
            int index = listMovie.FindIndex(x => x.Id == obj.Id);
            listMovie.Remove(listMovie[index]);
            if(!listMovie.Any())
            {
                Session["cart"] = null;
                Session["count"] = null;
            } else
            {
                Session["cart"] = listMovie;
                Session["count"] = listMovie.Count();
            }
            
            return RedirectToAction("Myorder", "AddToCart");
        }



        [HttpPost]
        public ActionResult CheckOut(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                newCustomer = true;
                return RedirectToAction("Myorder","AddToCart");
            }
            else
            { 
                var query = db.Customers.ToList()
                            .Find(m => m.EmailAddress.Contains(Email));

                if (query == null)
                {
                    newCustomer = true;
                    return RedirectToAction("Myorder", "AddToCart");
                }
                else
                {

                    List<Movie> li = (List<Movie>)Session["cart"];

                    Decimal total = 0;
                    foreach (Movie movie in li)
                    {
                        total += movie.Price;
                    }
                    Order order = new Order();
                    order.OrderDate = System.DateTime.Now.Date;
                    order.OrderPrice = total;
                    order.CustomerId = query.Id;

                    this.db.Orders.Add(order);
                    this.db.SaveChanges();

                    foreach (Movie movie in li)
                    {
                        OrderRow ordRow = new OrderRow();
                        ordRow.OrderId = order.Id;
                        ordRow.MovieId = movie.Id;
                        ordRow.Price = movie.Price;

                        this.db.OrderRows.Add(ordRow);
                        this.db.SaveChanges();
                    }
                    Session["cart"] = null;
                    Session["count"] = null;
                    newCustomer = false;
                    return View("~/Views/AddToCart/OrderSuccess.cshtml");
                }

                

            }
            
        }

    }
}