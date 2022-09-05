using BetaMovieStore.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetaMovieStore.ViewModel
{
    public class CartVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
        public List<Movie> Movies { get; set; }

    }
}