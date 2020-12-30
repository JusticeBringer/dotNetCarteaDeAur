using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace dotNetCarteaDeAur.Models
{   
    [Table("Books")]
    public class Book
    {
        [Key]
        // No need for validation - it is not completed by user
        public int Book_id { get; set; }

        [Required, 
        MinLength(10, ErrorMessage = "Title cannot be less than 10"),
        MaxLength(80, ErrorMessage = "Title cannot be more than 80")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z]{9,79}$", ErrorMessage = "This is not a valid book title!")]
        // Title has to be start with letters 
        // and contains letters characters in 10 to 80 length
        public string Title { get; set; }

        [Required,
        MinLength(4, ErrorMessage = "Author cannot be less than 4"),
        MaxLength(80, ErrorMessage = "Author cannot be more than 80")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z]{3,79}$", ErrorMessage = "This is not a valid book author name!")]
        // Author has to be start with letters 
        // and contains letters characters in 4 to 80 length
        public string Author { get; set; }

        [Required]
        // No validation here - using DateTime.TryParseExact at registering
        public DateTime PublishDate { get; set; }

        [Required]
        [RegularExpression(@"[0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*", ErrorMessage = "This is not a valid ISBN number!")]
        public string ISBN { get; set; }

        [Required]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "This is not a valid price")]
        // starts with number, ends with number, accepts decimals
        public double Price { get; set; }

        [Required]
        [RegularExpression(@"^\d\d*$", ErrorMessage = "This is not a book quantity")]
        // starts with number, ends with number
        public int Quantity { get; set; }

        [Required]
        // No validation here - validation at file uploading
        public string ImagePath { get; set; }

        // one to many
        [Column("Pub_id")]
        // No need for validation - it is not completed by user
        public int Pub_id { get; set; }
        public virtual Publisher Publisher { get; set; }

        public Book ()
        {
            this.Orders = new HashSet<Order>();
        }

        // many-to-many with order
        public virtual ICollection<Order> Orders { get; set; }
    }
}