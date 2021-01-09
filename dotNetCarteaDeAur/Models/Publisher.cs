using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace dotNetCarteaDeAur.Models
{
    [Table("Publishers")]
    public class Publisher
    {
        [Key]
        // No need for validation - it is not completed by user
        public int Pub_id { get; set; }
        //[Required]
        //[RegularExpression(@"^([a-zA-Z]+(?:[ -][a-zA-Z]+)*){5,19}$", ErrorMessage = "This is not a valid publisher name!")]
        // Publisher name has to be start with letters 
        // followed by any char dot and spaces
        // and contains letters characters in 6 to 20 length
        public string Pub_name { get; set; }

        // many-to-one relationship
        public virtual ICollection<Book> Books { get; set; }

        // one-to-one
        [Required]
        // already validated
        public virtual PubContact Pub_Contact { get; set; }
    }
}