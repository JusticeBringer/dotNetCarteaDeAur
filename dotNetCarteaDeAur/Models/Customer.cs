using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dotNetCarteaDeAur.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Cust_id { get; set; }

        [Required]

        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        // postal code
        public string P_code { get; set; }

        [Required]
        public string Phone { get; set; }

        // many-to-one 
        public virtual ICollection<Order> Orders { get; set; }
    }
}