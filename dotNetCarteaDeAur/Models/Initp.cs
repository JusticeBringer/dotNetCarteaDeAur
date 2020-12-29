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
            ctx.Books.Add(new Book { Title = "The Atomic Times", Author = "Michael Harris" });
            ctx.Books.Add(new Book { Title = "In Defense of Elitism", Author = "Joel Stein" });
            ctx.Books.Add(new Book { Title = "Data curenta", Author = DateTime.Now.ToString() });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}