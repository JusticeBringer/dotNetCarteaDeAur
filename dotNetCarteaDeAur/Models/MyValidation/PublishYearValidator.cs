using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dotNetCarteaDeAur.Models.MyValidation
{
    public class PublishYearValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var book = (Book)validationContext.ObjectInstance;
            int publishYear = book.PublishDate;
            int currYear = DateTime.Now.Year;

            bool cond = true;

            // first published book is considered to be in year 868 
            if (publishYear > currYear || publishYear < 868)
            {
                cond = false;
            }

            return cond ? ValidationResult.Success : new ValidationResult("This is not a valid publishing year!");
        }
    }
}