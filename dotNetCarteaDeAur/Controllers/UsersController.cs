﻿using dotNetCarteaDeAur.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace dotNetCarteaDeAur.Controllers
{
    // poate fi accesat doar de catre Admin
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {   
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.UsersList = ctx.Users
            .OrderBy(u => u.UserName)
            .ToList();

            return View();
        }
        public ActionResult Details(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return HttpNotFound("Missing the id parameter!");
            }

            ApplicationUser user = ctx.Users
            .Include("Roles")
            .FirstOrDefault(u => u.Id.Equals(id));

            if (user != null)
            {
                ViewBag.UserRole = ctx.Roles
                .Find(user.Roles.First().RoleId).Name;
                return View(user);
            }

            return HttpNotFound("Coudn't find the user with given id!");
        }

        public ActionResult Delete(string username)
        {
            if (username != null)
            {
                try
                {
                    Membership.DeleteUser(username, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return View("Index");
                }

                return RedirectToAction("Index", "Home");
            }

            return HttpNotFound("Couldn't find user with the username " + username.ToString());
        }

        public ActionResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return HttpNotFound("Missing the id parameter!");
            }

            UserViewModel uvm = new UserViewModel();
            uvm.User = ctx.Users.Find(id);

            IdentityRole userRole = ctx.Roles
            .Find(uvm.User.Roles.First().RoleId);

            uvm.RoleName = userRole.Name;
            return View(uvm);
        }
        [HttpPut]
        public ActionResult Edit(string id, UserViewModel uvm)
        {
            ApplicationUser user = ctx.Users.Find(id);
            try
            {
                if (TryUpdateModel(user))
                {
                    var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

                    foreach (var r in ctx.Roles.ToList())
                    {
                        um.RemoveFromRole(user.Id, r.Name);
                    }

                    um.AddToRole(user.Id, uvm.RoleName);
                    ctx.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View(uvm);
            }
        }
    }
}