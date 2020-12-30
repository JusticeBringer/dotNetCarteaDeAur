using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace dotNetCarteaDeAur.Models
{
    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            // creating default publisher
            Publisher OD = new Publisher
            {
                Pub_id = 1,
                Pub_name = "Editura ‹‹Oastea Domnului››",
                PublisherContactInfo = new PublisherContactInfo
                {
                    Pub_contact_id = 1,
                    Pub_phone = "07123456789"
                }
            };

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
                PublishDate = new DateTime(2015, 12, 31),
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
                PublishDate = new DateTime(2016, 12, 31),
                ISBN = "978-3-16-148410-0",
                Price = 14.5,
                Quantity = 2,
                ImagePath = "/Assets/Images/maiLangaDomnulMeu.jpg",
                Publisher = OD
            });

            // Add 

            // Saving changes
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}