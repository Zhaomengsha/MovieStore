using BetaMovieStore.Data;
using BetaMovieStore.Models;
using BetaMovieStore.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetaMovieStore.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Statistics
            ()
        {
            var query = db.Customers.FirstOrDefault();

            return View(query);
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        //var newMovies = db.Movies.OrderByDescending(m => m.ReleaseYear).ThenBy(m => m.Title).Take(5).ToList();
        //var oldestMovies = db.Movies.OrderBy(m => m.ReleaseYear).ThenBy(m => m.Title).Take(5).ToList();
        //var cheapestMovies = db.Movies.OrderBy(m => m.Price).ThenBy(m => m.Title).Take(5).ToList();
        //HomeViewModels obj = new HomeViewModels();
        //obj.Top5newMovies = newMovies;
        //obj.Top5cheapestMovies = cheapestMovies;
        //obj.Top5oldestMovies = oldestMovies;
    }
}