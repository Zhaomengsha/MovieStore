using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetaMovieStore.Models.Database
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Billing Adress")]
        public string BillingAdress { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Billing Postcode")]
        public string BillingZip { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Billing City")]
        public string BillingCity { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Delivery Adress")]
        public string DeliveryAdress { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Delivery Postcode")]
        public string DeliveryZip { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Delivery City")]
        public string DeliveryCity { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}