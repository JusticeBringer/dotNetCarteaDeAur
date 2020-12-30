using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace dotNetCarteaDeAur.Models
{
    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            // creating default publisher contact
            PubContact OD_con = new PubContact
            {
                Pub_contact_id = 1,
                Pub_email = "contact@oasteadomnului.ro",
                Pub_phone = "0269 216 677",
                Pub_city = "Sibiu",
                Pub_street = "Str. Charles Darwin, nr. 11"
            };

            // creating seconday publisher contact
            PubContact Egumenita_con = new PubContact
            {
                Pub_contact_id = 2,
                Pub_email = "editura@egumenita.ro",
                Pub_phone = "0236 326730",
                Pub_city = "Galati",
                Pub_street = "Str. Mihail Kogalniceanu nr.29"
            };

            // creating default publisher
            Publisher OD = new Publisher
            {
                Pub_id = 1,
                Pub_name = "Editura ‹‹Oastea Domnului››",
                Pub_Contact = OD_con
            };
            // creating secondary publisher
            Publisher Egumenita = new Publisher
            {
                Pub_id = 2,
                Pub_name = "Editura Egumenita",
                Pub_Contact = Egumenita_con
            };

            // Adding publishers to database
            ctx.Publishers.Add(OD);
            ctx.Publishers.Add(Egumenita);

            // Add books
            ctx.Books.Add(new Book
            {
                Book_id = 1,
                Title = "Ce este Oastea Domnului",
                Author = "Pr. Iosif Trifa",
                PublishDate = new DateTime(2015, 12, 31),
                ISBN = "978-3-16-148410-0",
                Price = 14.5,
                Quantity = 2,
                ImagePath = "/Assets/Images/ceEsteOasteaDomnului.png",
                Publisher = OD
            });
            ctx.Books.Add(new Book
            {
                Book_id = 2,
                Title = "Spre Canaan",
                Author = "Pr. Iosif Trifa",
                PublishDate = new DateTime(2016, 12, 31),
                ISBN = "978-3-16-148410-0",
                Price = 14.5,
                Quantity = 2,
                ImagePath = "/Assets/Images/spreCanaan.png",
                Publisher = OD
            });
            ctx.Books.Add(new Book
            {
                Book_id = 3,
                Title = "Sabia Duhului",
                Author = "Pr. Iosif Trifa",
                PublishDate = new DateTime(2014, 12, 31),
                ISBN = "978-3-16-148410-0",
                Price = 14.5,
                Quantity = 2,
                ImagePath = "/Assets/Images/sabiaDuhului.png",
                Publisher = OD
            });
            ctx.Books.Add(new Book
            {
                Book_id = 4,
                Title = "Mai lângă Domnul meu",
                Author = "Pr. Iosif Trifa",
                PublishDate = new DateTime(2013, 12, 31),
                ISBN = "978-3-16-148410-0",
                Price = 14.5,
                Quantity = 2,
                ImagePath = "/Assets/Images/maiLangaDomnulMeu.jpg",
                Publisher = OD
            });

            // Adding customers

            ctx.Customers.Add(new Customer
            {
                Cust_id = 1,
                First_name = "John",
                Last_name = "Lenon",
                City = "Galati",
                Street = "Str. Crizanthemes",
                P_code = "807178",
                Phone = "40745566921"
            });
            ctx.Customers.Add(new Customer
            {
                Cust_id = 2,
                First_name = "Vasile",
                Last_name = "Conan",
                City = "Bucharest",
                Street = "Str. Ghiocelos",
                P_code = "807172",
                Phone = "40743566921"
            });
            ctx.Customers.Add(new Customer
            {
                Cust_id = 3,
                First_name = "Jordan",
                Last_name = "Klaw",
                City = "Cluj",
                Street = "Str. Center Square",
                P_code = "847172",
                Phone = "40743186921"
            });

            // Saving changes


            try
            {
                ctx.SaveChanges();
                base.Seed(ctx);
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }

        }
    }
}