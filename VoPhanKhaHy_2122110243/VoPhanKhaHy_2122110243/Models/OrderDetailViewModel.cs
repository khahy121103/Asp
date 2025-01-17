using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoPhanKhaHy_2122110243.Context;

namespace VoPhanKhaHy_2122110243.Models
{
    public class OrderDetailViewModel
    {
        public Order Order { get; set; }
        public List<OrderDetailInfo> OrderDetails { get; set; }
    }
    public class OrderDetailInfo
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}