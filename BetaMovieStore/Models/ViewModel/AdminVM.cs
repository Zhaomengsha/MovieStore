using BetaMovieStore.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetaMovieStore.Models.ViewModel
{
    public class AdminVM
    {
        public List<Customer> Customers { get; set; }
        public List<Movie> Movies { get; set; }
      
        
        public List<OrderDetailVM> OrderDetails { get; set; }
    }
}