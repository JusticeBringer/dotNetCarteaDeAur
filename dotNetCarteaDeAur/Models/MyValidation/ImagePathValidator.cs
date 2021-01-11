using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dotNetCarteaDeAur.Models.MyValidation
{

    public class ImagePathValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Example path: /Assets/Images/exemplu.jpg

            var book = (Book)validationContext.ObjectInstance;
            string imgPath = book.ImagePath;
            string imgValidPath = "/Assets/Images/";
            int pathLength = imgValidPath.Length;
            int counter = -1;
            string[] extensions = { "png", "jpg" };

            // file should be jpg or png
            foreach (char c in imgPath)
            {
                counter++;
                // we verify to have '/Assets/Images/'
                if (counter < pathLength)
                {
                    if (c != imgValidPath[counter])
                    {
                        return new ValidationResult("This is not a valid image path!");
                    }
                }
                else
                {
                    // we try to know when file extension will be
                    if (c == '.')
                    {
                        // we passed the dot and the file has less than 3 characters
                        if ((imgPath.Length - (counter + 4)) < 0)
                        {
                            return new ValidationResult("File does not have extension");
                        }

                        // we determine the image extension
                        counter++;
                        string imgPathExt = imgPath[counter].ToString() + imgPath[counter + 1].ToString() + imgPath[counter + 2].ToString();

                        if (imgPathExt == "png" || imgPathExt == "jpg")
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult("File extension can only be 'jpg' or 'png'");
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return new ValidationResult("This is not a valid image path! File extension can only be 'jpg' or 'png'");
        }
    }
}