using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCarteaDeAur.Models
{
    [Table("PublisherContactInfos")]
    public class PublisherContactInfo
    {
        [Key]
        public int Pub_contact_id { get; set; }
        [Required]
        public string Pub_phone { get; set; }

        // one-to-one
        public virtual Publisher Publisher { get; set; }
    }
}