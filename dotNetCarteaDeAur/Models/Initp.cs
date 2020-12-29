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
                Publisher = new Publisher
                {
                    Pub_id = 1,
                    Pub_name = "Editura ‹‹Oastea Domnului››",
                    PublisherContactInfo = new PublisherContactInfo
                    {
                        Pub_contact_id = 1,
                        Pub_phone = "07123456789"
                    }
                }
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
                Publisher = new Publisher
                {
                    Pub_id = 1,
                    Pub_name = "Editura ‹‹Oastea Domnului››",
                    PublisherContactInfo = new PublisherContactInfo
                    {
                        Pub_contact_id = 1,
                        Pub_phone = "07123456789"
                    }
                }
            }); ;

            // Add 

            // Saving changes
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}