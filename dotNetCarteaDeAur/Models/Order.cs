using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dotNetCarteaDeAur.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Ord_id { get; set; }

        [Required]
        public double Ord_price { get; set; }

        [Required]
        public DateTime Ord_placed { get; set; }

        public DateTime? Ord_arrived { get; set; }

        public string? Status { get; set; }

        // one to many
        [Column("Cust_id")]
        public int Cust_id { get; set; }
        public virtual Customer Customer { get; set; }

        // many-to-one relationship
        public virtual ICollection<Orders_items> Orders_Items { get; set; }
    }
}