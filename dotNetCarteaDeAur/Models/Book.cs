using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace dotNetCarteaDeAur.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class DbCtx : DbContext
    {
        public DbCtx() : base("GoldenBookDB")
        {
            // set the initializer here
            Database.SetInitializer<DbCtx>(new Initp());
        }
        public DbSet<Book> Books { get; set; }
    }
}