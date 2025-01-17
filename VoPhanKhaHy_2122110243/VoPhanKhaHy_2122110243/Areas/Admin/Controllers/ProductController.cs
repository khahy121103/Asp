using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoPhanKhaHy_2122110243.Context;
using System.IO;
using System.Data.Entity;
using System.Security.AccessControl;
using System.Data.Common;
using System.Data;
using System.Runtime.Remoting.Messaging;
using PagedList;

namespace VoPhanKhaHy_2122110243.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebASPEntities db = new WebASPEntities();

        // GET: Admin/Product
        public ActionResult Index(string Search,string currentFilter, int? page)
        {
            var listProduct = new List<Product>();
            if(Search != null)
            {
                page = 1;
            }
            else
            {
                Search = currentFilter;
            }
            if(!String.IsNullOrEmpty(Search))
            {
                listProduct = db.Products.Where(n => n.Name.Contains(Search)).ToList();
            }
            else
            {
                listProduct = db.Products.ToList();
            }
            ViewBag.CurrentFilter = Search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listProduct = listProduct.OrderByDescending(n => n.Id).ToList();
            return View(listProduct.ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            this.LoadData();

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ImageUpLoad != null && product.ImageUpLoad.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(product.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(product.ImageUpLoad.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        product.Avartar = fileName;
                        product.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                    }
                    product.CreatedOnUtc = DateTime.Now;
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }
            
        
        [HttpGet]
        public ActionResult Details(int id)
        {
            var Product = db.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(Product);
        }
        

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Product = db.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(Product);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var Product = db.Products.Where(n => n.Id == product.Id).FirstOrDefault();
            db.Products.Remove(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Product = db.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(Product);
        }
        [HttpPost]
        public ActionResult Edit(Product product,int id)
        {
            if (product.ImageUpLoad != null && product.ImageUpLoad.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageUpLoad.FileName);
                string extension = Path.GetExtension(product.ImageUpLoad.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                product.Avartar = fileName;
                product.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
            }
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        void LoadData()
        {
            Common objCommon = new Common();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();

            var listCategory = db.Categories.ToList();
            DataTable dtCategory = converter.ToDataTable(listCategory);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            var listBrands = db.Brands.ToList();
            DataTable dtBrands = converter.ToDataTable(listBrands);
            ViewBag.ListBrands = objCommon.ToSelectList(dtBrands, "Id", "Name");

            List<ProductType> listProductType = new List<ProductType>();
            ProductType productType = new ProductType();
            productType.Id = 1;
            productType.Name = "Giảm giá sốc";
            listProductType.Add(productType);

            productType = new ProductType();
            productType.Id = 2;
            productType.Name = "Đề xuất";
            listProductType.Add(productType);

            DataTable dtProductType = converter.ToDataTable(listProductType);
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }
    }
}