﻿using dotNetCarteaDeAur.Models.MyValidation;
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
        // No need for validation - it is not completed by user
        public int Ord_id { get; set; }

        [Required]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "This is not a valid price")]
        // starts with number, ends with number, accepts decimals
        public double Ord_price { get; set; }

        [Required]
        // No validation here - using DateTime.TryParseExact at registering
        public DateTime Ord_placed { get; set; }

        // No validation here - using DateTime.TryParseExact at registering
        public DateTime? Ord_arrived { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z]{3,19}$", ErrorMessage = "This is not a valid status!")]
        // Status has to start with letters 
        // and contains letters characters in 4 to 20 length
        #pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Status { get; set; }
        #pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        [Required]
        [QuantityValidator]
        // "2 8 12 4" meaning is that user bought 2, 8, 12, 4 books of the Books array
        public List<int> Quantity_bought { set; get; }

        // one to many
        [Column("Cust_id")]
        public int Cust_id { get; set; }
        public virtual Customer Customer { get; set; }

        // many-to-many with books
        public virtual ICollection<Book> Books { get; set; }
    }
}