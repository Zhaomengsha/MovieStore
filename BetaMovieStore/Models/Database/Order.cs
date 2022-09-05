using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetaMovieStore.Models.Database
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Decimal OrderPrice { get; set; }

        public int CustomerId { get; set; }

        public /*virtual*/ Customer Customer { get; set; }
        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}