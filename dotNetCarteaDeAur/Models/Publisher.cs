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
        public int Pub_id { get; set; }
        [Required]
        public string Pub_name { get; set; }

        // many-to-one relationship
        public virtual ICollection<Book> Books { get; set; }

        // one-to-one
        [Required]
        public virtual PubContact Pub_Contact { get; set; }
    }
}