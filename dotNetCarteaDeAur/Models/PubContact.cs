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
        // No need for validation - it is not completed by user
        public int Pub_contact_id { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "This is not a valid email!")]
        public string Pub_email { get; set; }

        [Required]
        [RegularExpression(@"^07(\d{8})$", ErrorMessage = "This is not a valid phone number!")]
        public string Pub_phone { get; set; }

        [Required]
        [RegularExpression(@"^[#.0-9a-zA-Z\s,-]+$", ErrorMessage = "This is not a valid city!")]
        public string Pub_city { get; set; }

        [Required]
        [RegularExpression(@"^[#.0-9a-zA-Z\s,-]+$", ErrorMessage = "This is not a valid street!")]
        public string Pub_street { get; set; }

        // one-to-one
        public virtual Publisher Publisher { get; set; }
    }
}