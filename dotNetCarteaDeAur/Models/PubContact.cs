using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dotNetCarteaDeAur.Models
{
    [Table("PubContact")]
    public class PubContact
    {
        [Key]
        public int Pub_contact_id { get; set; }

        [Required]
        public string Pub_email { get; set; }

        [Required]
        public string Pub_phone { get; set; }

        [Required]
        public string Pub_city { get; set; }

        [Required]
        public string Pub_street { get; set; }

        // one-to-one
        public virtual Publisher Publisher { get; set; }
    }
}