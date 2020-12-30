using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dotNetCarteaDeAur.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        // No need for validation - it is not completed by user
        public int Cust_id { get; set; }

        [Required,
        MinLength(2, ErrorMessage = "First name cannot be less than 2"),
        MaxLength(50, ErrorMessage = "First name cannot be more than 50")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z]{1,49}$", ErrorMessage = "This is not a valid first name!")]
        // First name has to start with letters 
        // and contains letters characters in 2 to 50 length
        public string First_name { get; set; }

        [Required,
        MinLength(2, ErrorMessage = "Last name cannot be less than 2"),
        MaxLength(50, ErrorMessage = "Last name cannot be more than 50")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z]{1,49}$", ErrorMessage = "This is not a valid last name!")]
        // Last name has to start with letters 
        // and contains letters characters in 2 to 50 length
        public string Last_name { get; set; }

        [Required]
        [RegularExpression(@"^[#.0-9a-zA-Z\s,-]+$", ErrorMessage = "This is not a valid city!")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[#.0-9a-zA-Z\s,-]+$", ErrorMessage = "This is not a valid street!")]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"\d{6}", ErrorMessage = "This is not a valid postal code!")]
        // Postal code contains only 6 digits in Romania
        public string P_code { get; set; }

        [Required]
        [RegularExpression(@"^07(\d{8})$", ErrorMessage = "This is not a valid phone number!")]
        public string Phone { get; set; }

        // many-to-one 
        public virtual ICollection<Order> Orders { get; set; }
    }
}