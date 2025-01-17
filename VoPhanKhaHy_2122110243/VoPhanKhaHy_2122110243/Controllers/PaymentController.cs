using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoPhanKhaHy_2122110243.Context;
using VoPhanKhaHy_2122110243.Models;

namespace VoPhanKhaHy_2122110243.Controllers
{
    public class PaymentController : Controller
    {
        WebASPEntities db = new WebASPEntities();

        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                // Lấy giỏ hàng từ session
                var listCart = (List<CartModel>)Session["cart"];
                if (listCart == null || !listCart.Any())
                {
                    return RedirectToAction("Index", "Home"); // Nếu giỏ hàng rỗng, quay về trang chủ
                }

                // Tạo đơn hàng mới
                Order order = new Order();
                order.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                order.UserId = int.Parse(Session["idUser"].ToString());
                order.CreatedOnUtc = DateTime.Now;
                order.Status = 1; // Trạng thái đơn hàng, có thể thay đổi tùy thuộc vào logic ứng dụng của bạn
                db.Orders.Add(order);
                db.SaveChanges();

                int intOrderId = order.Id;

                // Tạo chi tiết đơn hàng từ giỏ hàng
                List<OrderDetail> listOrderDetail = new List<OrderDetail>();

                foreach (var item in listCart)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OderId = intOrderId;
                    orderDetail.ProductId = item.Product.Id;
                    orderDetail.Quantity = item.Quantity;
                    listOrderDetail.Add(orderDetail);
                }

                // Lưu chi tiết đơn hàng vào cơ sở dữ liệu
                db.OrderDetails.AddRange(listOrderDetail);
                db.SaveChanges();

                // Xóa giỏ hàng và cập nhật lại session["count"]
                Session["cart"] = null;
                Session["count"] = 0;  // Cập nhật số lượng giỏ hàng về 0

                // Trả về view cho người dùng sau khi thanh toán thành công
                return View();
            }
        }
    }
}
