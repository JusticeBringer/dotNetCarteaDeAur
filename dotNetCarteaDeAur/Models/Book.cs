﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace dotNetCarteaDeAur.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Book_id { get; set; }

        [Required, 
        MinLength(10, ErrorMessage = "Title cannot be less than 10"),
        MaxLength(800, ErrorMessage = "Title cannot be more than 80")]
        public string Title { get; set; }

        [Required,
        MinLength(4, ErrorMessage = "Author cannot be less than 4"),
        MaxLength(80, ErrorMessage = "Author cannot be more than 80")]
        public string Author { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        // one to many
        [Column("Pub_id")]
        public int Pub_id { get; set; }
        public Publisher Publishers { get; set; }
        public virtual Publisher Publisher { get; set; }

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
        public DbSet<PublisherContactInfo> PublisherContactInfos { get; set; }

    }
}