using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace dotNetCarteaDeAur.Models
{
    public class API
    {

    }

    public class DbCtx : DbContext
    {
        public DbCtx() : base("GoldenBookDB")
        {
            // set the initializer here
            Database.SetInitializer<DbCtx>(new Initp());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}