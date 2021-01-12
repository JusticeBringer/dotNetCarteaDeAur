using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dotNetCarteaDeAur.Models.MyValidation
{
    public class QuantityValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;
            bool cond = true;

            foreach (var v in order.Quantity_bought)
            {
                if (!(v is int))
                {
                    cond = false;
                    break;
                }
            }

            return cond ? ValidationResult.Success : new ValidationResult("This is not a valid publishing year!");
        }
    }
}