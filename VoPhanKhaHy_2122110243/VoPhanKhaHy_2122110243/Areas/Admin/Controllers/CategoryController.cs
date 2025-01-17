using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoPhanKhaHy_2122110243.Context;
using System.IO;
using PagedList;

namespace VoPhanKhaHy_2122110243.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        WebASPEntities db = new WebASPEntities();

        // GET: Admin/Category
        public ActionResult Index(string Search, string currentFilter, int? page)
        {
            var listCategory = new List<Category>();
            if (Search != null)
            {
                page = 1;
            }
            else
            {
                Search = currentFilter;
            }
            if (!String.IsNullOrEmpty(Search))
            {
                listCategory = db.Categories.Where(n => n.Name.Contains(Search)).ToList();
            }
            else
            {
                listCategory = db.Categories.ToList();
            }
            ViewBag.CurrentFilter = Search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listCategory = listCategory.OrderByDescending(n => n.Id).ToList();
            return View(listCategory.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (category.ImageUpLoad != null && category.ImageUpLoad.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(category.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(category.ImageUpLoad.FileName);
                        category.Avartar = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        category.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/images/category/"), fileName));
                    }
                    category.CreatedOnUtc = DateTime.Now;
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Không tạo đc.");
                }
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var category = db.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = db.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra nếu có ảnh mới được tải lên
                    if (category.ImageUpLoad != null && category.ImageUpLoad.ContentLength > 0)
                    {
                        // Tạo tên file ảnh mới
                        string fileName = Path.GetFileNameWithoutExtension(category.ImageUpLoad.FileName);
                        string extension = Path.GetExtension(category.ImageUpLoad.FileName);
                        string newFileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;

                        // Lưu ảnh vào thư mục
                        string path = Path.Combine(Server.MapPath("~/Content/images/category/"), newFileName);
                        category.ImageUpLoad.SaveAs(path);

                        // Cập nhật trường Avartar với tên file mới
                        category.Avartar = newFileName;
                    }
                    else
                    {
                        // Không cập nhật ảnh, giữ nguyên giá trị cũ
                        db.Entry(category).Property(x => x.Avartar).IsModified = false;
                    }

                    // Cập nhật các thông tin khác
                    category.UpdatedOnUtc = DateTime.Now;
                    db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error occurred while updating the category: " + ex.Message);
                }
            }
            return View(category);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            try
            {
                var categoryToDelete = db.Categories.Where(n => n.Id == category.Id).FirstOrDefault();
                db.Categories.Remove(categoryToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while deleting the category.");
                return View(category);
            }
        }
    }
}
