using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace dotNetCarteaDeAur.Models
{
    public class Orders_items
    {
        [Key]
        public int Ord_id { get; set; }
        [Required]
        public int Quantity_bought { set; get; }
    }
}