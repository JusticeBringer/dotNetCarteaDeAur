﻿using System;
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
            // Create default publisher contact
            PubContact OD_con = new PubContact
            {
                Pub_contact_id = 1,
                Pub_email = "contact@oasteadomnului.ro",
                Pub_phone = "0269216677",
                Pub_city = "Sibiu",
                Pub_street = "Str. Charles Darwin, nr. 11"
            };
            // Create seconday publisher contact
            PubContact Egumenita_con = new PubContact
            {
                Pub_contact_id = 2,
                Pub_email = "editura@egumenita.ro",
                Pub_phone = "0236326730",
                Pub_city = "Galati",
                Pub_street = "Str. Mihail Kogalniceanu nr.29"
            };

            // Create default publisher
            Publisher OD = new Publisher
            {
                Pub_id = 1,
                Pub_name = "Oastea Domnului",
                Pub_Contact = OD_con
            };
            // Create secondary publisher
            Publisher Egumenita = new Publisher
            {
                Pub_id = 2,
                Pub_name = "Egumenita",
                Pub_Contact = Egumenita_con
            };

            // Create books
            Book b1 = new Book
            {
                Book_id = 1,
                Title = "Ce este Oastea Domnului",
                Author = "Pr. Iosif Trifa",
                PublishDate = 2015,
                ISBN = "978-3-16-148410-0",
                Price = 15,
                Quantity = 24,
                ImagePath = "/Assets/Images/ceEsteOasteaDomnului.png",
                Publisher = OD
            };
            Book b2 = new Book
            {
                Book_id = 2,
                Title = "Spre Canaan",
                Author = "Pr. Iosif Trifa",
                PublishDate = 2016,
                ISBN = "978-3-16-148410-0",
                Price = 14,
                Quantity = 45,
                ImagePath = "/Assets/Images/spreCanaan.png",
                Publisher = OD
            };
            Book b3 = new Book
            {
                Book_id = 3,
                Title = "Sabia Duhului",
                Author = "Pr. Iosif Trifa",
                PublishDate = 2014,
                ISBN = "978-3-16-148410-0",
                Price = 8,
                Quantity = 20,
                ImagePath = "/Assets/Images/sabiaDuhului.png",
                Publisher = OD
            };
            Book b4 = new Book
            {
                Book_id = 4,
                Title = "Mai langa Domnul meu",
                Author = "Pr. Iosif Trifa",
                PublishDate = 2013,
                ISBN = "978-3-16-148410-0",
                Price = 7,
                Quantity = 30,
                ImagePath = "/Assets/Images/maiLangaDomnulMeu.jpg",
                Publisher = OD
            };

            Book b5 = new Book
            {
                Book_id = 5,
                Title = "Toiagul Odraslit",
                Author = "Pr. Gheorghe Coltea",
                PublishDate = 2015,
                ISBN = "978-3-16-148430-0",
                Price = 33,
                Quantity = 15,
                ImagePath = "/Assets/Images/egumenita1.jpg",
                Publisher = Egumenita
            };

            Book b6 = new Book
            {
                Book_id = 6,
                Title = "Un episcop neconformist",
                Author = "Egumenul Damaschin",
                PublishDate = 2015,
                ISBN = "978-3-16-138430-0",
                Price = 10,
                Quantity = 19,
                ImagePath = "/Assets/Images/egumenita2.jpg",
                Publisher = Egumenita
            };

            Book b7 = new Book
            {
                Book_id = 7,
                Title = "Craciunul si Pastile aduc bucuriile",
                Author = "Arhiepiscopul Andrei",
                PublishDate = 2014,
                ISBN = "978-3-16-128430-0",
                Price = 17,
                Quantity = 35,
                ImagePath = "/Assets/Images/egumenita3.jpg",
                Publisher = Egumenita
            };

            Book b8 = new Book
            {
                Book_id = 8,
                Title = "Spovedania unui avocat",
                Author = "Mirela Chelaru",
                PublishDate = 2015,
                ISBN = "978-3-16-108430-0",
                Price = 12,
                Quantity = 40,
                ImagePath = "/Assets/Images/egumenita4.jpg",
                Publisher = Egumenita
            };

            // Create customers
            Customer c1 = new Customer
            {
                Email = "johnHello@gmail.com",
                Password = "Cheiedesecuritat3#",
                Cust_id = 1,
                First_name = "John",
                Last_name = "Lenon",
                City = "Galati",
                Street = "Str. Crizanthemes",
                P_code = "807178",
                Phone = "0745566921"
            };
            Customer c2 = new Customer
            {
                Email = "vasileHello@gmail.com",
                Password = "Cheiedesecuritat3#",
                Cust_id = 2,
                First_name = "Vasile",
                Last_name = "Conan",
                City = "Bucharest",
                Street = "Str. Ghiocelos",
                P_code = "807172",
                Phone = "0743566921"
            };
            Customer c3 = new Customer
            {
                Email = "jordanHello@gmail.com",
                Password = "Cheiedesecuritat3#",
                Cust_id = 3,
                First_name = "Jordan",
                Last_name = "Klaw",
                City = "Cluj",
                Street = "Str. Center Square",
                P_code = "847172",
                Phone = "0743186921"
            };

            // Create orders

            Order o1 = new Order
            {
                Ord_id = 1,
                Ord_price = 145.23,
                Ord_placed = new DateTime(2013, 12, 31),
                Ord_arrived = new DateTime(2014, 10, 30),
                Status = "Delivered",
                Cust_id = 1,
                Quantity_bought = new List<int>()
                { 
                    1, 2
                },
                Books = new List<Book>()
                {
                    b1, b2
                },
                Customer = c1
            };
            Order o2 = new Order
            {
                Ord_id = 2,
                Ord_price = 125.23,
                Ord_placed = new DateTime(2013, 10, 24),
                Ord_arrived = new DateTime(2013, 11, 30),
                Status = "Delivered",
                Cust_id = 2,
                Quantity_bought = new List<int>()
                {
                    4, 2
                },
                Books = new List<Book>()
                {
                    b2, b3
                },
                Customer = c2
            };
            Order o3 = new Order
            {
                Ord_id = 3,
                Ord_price = 105.23,
                Ord_placed = new DateTime(2012, 10, 24),
                Cust_id = 3,
                Quantity_bought = new List<int>()
                {
                    1, 3
                },
                Books = new List<Book>()
                {
                    b1, b4
                },
                Customer = c3
            };

            // Create lists for all tables

            // Publishers list
            List<Publisher> publishers = new List<Publisher>()
            {
                OD,
                Egumenita
            };

            // Books list
            List<Book> books = new List<Book>()
            {
                b1, b2, b3, b4, b5, b6, b7, b8
            };

            // Customers list
            List<Customer> customers = new List<Customer>
            {
                c1, c2, c3
            };

            // Orders list
            List<Order> orders = new List<Order>()
            {
                o1, o2, o3
            };

            // Add customers to database
            foreach (Customer c in customers)
            {
                ctx.Customers.Add(c);
            }

            // Add publishers to database
            foreach (Publisher p in publishers)
            {
                ctx.Publishers.Add(p);
            }

            // Add books to database
            foreach (Book b in books)
            {
                ctx.Books.Add(b);
            }

            // Add orders to database
            foreach (Order o in orders)
            {
                ctx.Orders.Add(o);
            }


            // Save changes to database
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