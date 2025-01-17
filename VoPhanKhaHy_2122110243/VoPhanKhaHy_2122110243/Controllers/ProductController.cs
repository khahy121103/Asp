using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoPhanKhaHy_2122110243.Context;

namespace VoPhanKhaHy_2122110243.Controllers
{
    public class ProductController : Controller
    {
        WebASPEntities db = new WebASPEntities();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = db.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        public ActionResult ListingGrid()
        {
            return View();
        }
        public ActionResult ListingList()
        {
            return View();
        }
    }
}