using BetaMovieStore.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetaMovieStore.Models.ViewModel
{
    public class OrderDetailVM
    {
        public Order OrderOfCustomer { get; set; }

        public List<OrderRow> OrderRowsOfCustomer { get; set; }
        
    }
}