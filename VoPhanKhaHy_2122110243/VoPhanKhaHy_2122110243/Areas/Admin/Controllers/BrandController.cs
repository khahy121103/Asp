using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoPhanKhaHy_2122110243.Context;
using PagedList;
using System.IO;

namespace VoPhanKhaHy_2122110243.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        WebASPEntities db = new WebASPEntities();

        // GET: Admin/Brand
        public ActionResult Index(string currentFilter, int? page)
        {
            var listBrand = new List<Brand>();

            // Set the current filter from the session or from the URL
            if (currentFilter != null)
            {
                page = 1; // Reset page to 1 if search is triggered
            }

            // Fetch all brands if no search filter is applied
            listBrand = db.Brands.ToList();

            ViewBag.CurrentFilter = currentFilter; // Save current filter as a string to show in the search field

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listBrand = listBrand.OrderByDescending(n => n.Id).ToList();

            return View(listBrand.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Brand/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brand/Create
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra nếu có ảnh được tải lên
                    if (brand.ImageUpLoad != null && brand.ImageUpLoad.ContentLength > 0)
                    {
                        // Tạo tên file duy nhất dựa trên thời gian
                        string fileName = Path.GetFileNameWithoutExtension(brand.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(brand.ImageUpLoad.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;

                        // Gán tên file vào thuộc tính Avartar
                        brand.Avartar = fileName;

                        // Lưu file vào thư mục cụ thể
                        string path = Path.Combine(Server.MapPath("~/Content/images/brands/"), fileName);
                        brand.ImageUpLoad.SaveAs(path);
                    }

                    // Gán thời gian tạo (CreatedOnUtc)
                    brand.CreatedOnUtc = DateTime.Now;

                    // Thêm vào cơ sở dữ liệu
                    db.Brands.Add(brand);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Không tạo được thương hiệu.");
                }
            }
            return View(brand);
        }


        // GET: Admin/Brand/Details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var brand = db.Brands.Where(b => b.Id == id).FirstOrDefault();
            if (brand != null)
            {
                return View(brand);
            }
            return HttpNotFound();
        }

        // GET: Admin/Brand/Edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var brand = db.Brands.Where(b => b.Id == id).FirstOrDefault();
            if (brand != null)
            {
                return View(brand);
            }
            return HttpNotFound();
        }

        // POST: Admin/Brand/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Lỗi xảy ra khi cập nhật thương hiệu.");
                }
            }
            return View(brand);
        }

        // GET: Admin/Brand/Delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var brand = db.Brands.Where(b => b.Id == id).FirstOrDefault();
            if (brand != null)
            {
                return View(brand);
            }
            return HttpNotFound();
        }

        // POST: Admin/Brand/Delete/{id}
        [HttpPost]
        public ActionResult Delete(Brand brand)
        {
            try
            {
                var brandToDelete = db.Brands.Where(b => b.Id == brand.Id).FirstOrDefault();
                db.Brands.Remove(brandToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Lỗi xảy ra khi xóa thương hiệu.");
                return View(brand);
            }
        }
    }
}
