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
        public string? Status { get; set; }

        [Required]
        [RegularExpression(@"^[0-9][0-9]$", ErrorMessage = "This is not a valid quantity bought!")]
        // Quantity has to start with numbers and end with numbers
        // "2 8 12 4" meaning is that user bought 2, 8, 12, 4 books of the Books array
        public string Quantity_bought { set; get; }

        // one to many
        [Column("Cust_id")]
        // No need for validation - it is not completed by user
        public int Cust_id { get; set; }
        public virtual Customer Customer { get; set; }

        // many-to-many with books
        public virtual ICollection<Book> Books { get; set; }
    }
}