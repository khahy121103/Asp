using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using VoPhanKhaHy_2122110243.Context;
using VoPhanKhaHy_2122110243.Models;

namespace VoPhanKhaHy_2122110243.Controllers
{
    public class HomeController : Controller
    {
        WebASPEntities db = new WebASPEntities();
        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();

            objHomeModel.ListProducts = db.Products.ToList();
            objHomeModel.ListCategories = db.Categories.ToList();

            return View(objHomeModel);
        }
        public ActionResult Content()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if(ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.IsAdmin = false;
                    _user.Password = GetMD5(_user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password, bool rememberMe = false)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    // Lưu session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().Id;

                    // Lưu cookie nếu chọn ghi nhớ
                    if (rememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("UserLogin");
                        cookie.Values["Email"] = email;
                        cookie.Values["Password"] = f_password;
                        cookie.Expires = DateTime.Now.AddDays(7); // Cookie tồn tại 7 ngày
                        Response.Cookies.Add(cookie);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email hoặc mật khẩu không chính xác!";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();

            // Xóa cookie
            if (Request.Cookies["UserLogin"] != null)
            {
                HttpCookie cookie = new HttpCookie("UserLogin");
                cookie.Expires = DateTime.Now.AddDays(-1); // Hết hạn ngay lập tức
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Login");
        }

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

        // Logic tự động đăng nhập bằng cookie
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["idUser"] == null && Request.Cookies["UserLogin"] != null)
            {
                HttpCookie cookie = Request.Cookies["UserLogin"];
                string email = cookie.Values["Email"];
                string password = cookie.Values["Password"];

                // Kiểm tra dữ liệu trong cơ sở dữ liệu
                var data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    // Tự động đăng nhập
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().Id;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}