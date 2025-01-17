using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoPhanKhaHy_2122110243.Context;
using System.IO;
using PagedList;
using System.Data;
using VoPhanKhaHy_2122110243.Models;

namespace VoPhanKhaHy_2122110243.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WebASPEntities db = new WebASPEntities();

        // GET: Admin/Order
        public ActionResult Index(DateTime? DateFrom, DateTime? DateTo, string currentFilter, int? page)
        {
            var listOrder = new List<Order>();

            if (DateFrom != null && DateTo != null)
            {
                page = 1; // Reset page to 1 if search is triggered
            }
            else
            {
                DateFrom = currentFilter != null ? (DateTime?)DateTime.Parse(currentFilter) : null;
            }

            if (DateFrom.HasValue && DateTo.HasValue)
            {
                // Filter orders by date range
                listOrder = db.Orders.Where(n => n.CreatedOnUtc >= DateFrom && n.CreatedOnUtc <= DateTo).ToList();
            }
            else
            {
                // If no date range, show all orders
                listOrder = db.Orders.ToList();
            }

            ViewBag.CurrentFilter = DateFrom?.ToString("yyyy-MM-dd"); // Save current filter as a string to show in the search field
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listOrder = listOrder.OrderByDescending(n => n.Id).ToList();

            return View(listOrder.ToPagedList(pageNumber, pageSize));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    order.CreatedOnUtc = DateTime.Now;
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Không tạo được đơn hàng.");
                }
            }
            return View(order);
        }

        [HttpGet]
        public ActionResult Details(int id)
{
    var order = db.Orders.Where(n => n.Id == id).FirstOrDefault();

    if (order != null)
    {
        // Fetch the order details based on the OrderId
        var orderDetails = db.OrderDetails.Where(od => od.OderId == id).ToList();

        // Fetch product info and assign it to the details list
        var orderDetailInfos = orderDetails.Select(od => new OrderDetailInfo
        {
            ProductId = od.ProductId,
            Quantity = od.Quantity,
            Price =(decimal) db.Products.Where(p => p.Id == od.ProductId).Select(p => p.Price).FirstOrDefault(),
            ProductName = db.Products.Where(p => p.Id == od.ProductId).Select(p => p.Name).FirstOrDefault(),
            TotalPrice = od.Quantity *(decimal) db.Products.Where(p => p.Id == od.ProductId).Select(p => p.Price).FirstOrDefault()
        }).ToList();

        // Pass the order and order details to the view
        var model = new OrderDetailViewModel
        {
            Order = order,
            OrderDetails = orderDetailInfos
        };

        return View(model);
    }

    return HttpNotFound();
}



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = db.Orders.Where(n => n.Id == id).FirstOrDefault();
            if (order == null) return HttpNotFound();
            ViewBag.OrderStatus = new SelectList(new[]
            {
                new { Value = 1, Text = "Đặt hàng thành công" },
                new { Value = 2, Text = "Đang xử lý" },
                new { Value = 3, Text = "Đã thanh toán" },
                new { Value = 4, Text = "Đang giao" },
                new { Value = 5, Text = "Hoàn thành" },
                new { Value = 6, Text = "Đã hủy" }
            }, "Value", "Text", order.Status);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Lỗi xảy ra khi cập nhật đơn hàng.");
                }
            }
            return View(order);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var order = db.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public ActionResult Delete(Order order)
        {
            try
            {
                var orderToDelete = db.Orders.Where(n => n.Id == order.Id).FirstOrDefault();
                db.Orders.Remove(orderToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Lỗi xảy ra khi xóa đơn hàng.");
                return View(order);
            }
        }
    }
}
