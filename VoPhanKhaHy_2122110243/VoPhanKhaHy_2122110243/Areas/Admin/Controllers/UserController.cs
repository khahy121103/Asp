using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VoPhanKhaHy_2122110243.Context;
using VoPhanKhaHy_2122110243.Models;

namespace VoPhanKhaHy_2122110243.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly WebASPEntities db = new WebASPEntities();

        // GET: Admin/User
        public ActionResult Index()
        {
            // Fetch users from the database
            var users = db.Users.ToList();  // Assuming `Users` is the name of your user table

            // Pass the users list to the view
            return View(users);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists
                var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    // Email already exists, handle the error
                    ViewBag.ErrorMessage = "Email already exists!";
                    return View(user);
                }


                user.Password = GetMD5(user.Password);

                // Add user to the database
                db.Users.Add(user);
                db.SaveChanges();

                // Redirect to the Index page after creating the user
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // Method to hash the password securely using SHA256
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            // Find the user by ID
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                // Update the user details
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                // Redirect to the Index page after editing the user
                return RedirectToAction("Index");
            }

            return View(user);
        }
        
        

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user by ID
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the user to delete
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

            // Redirect to the Index page after deleting the user
            return RedirectToAction("Index");
        }
    }
}
