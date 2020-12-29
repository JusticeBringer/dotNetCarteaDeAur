using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNetCarteaDeAur.Models
{
    public class Payment
    {
        public int Pay_id { get; set; }
        public string Bank_name { get; set; }
        public string Pay_method { get; set; }
    }
}