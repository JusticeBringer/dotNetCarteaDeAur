using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCarteaDeAur.Models
{
    public class Orders_items
    {
        public Orders_items()
        {
            this.Books = new HashSet<Book>();
        }

        [Required]
        public int[] Quantity_bought { set; get; }

        // one to many with orders
        [Key]
        [Column("Ord_id")]
        public int Ord_id { get; set; }
        public virtual Order Order { get; set; }

        // many-to-many with books
        public virtual ICollection<Book> Books { get; set; }
    }
}