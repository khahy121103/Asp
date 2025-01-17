using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoPhanKhaHy_2122110243.Context;

namespace VoPhanKhaHy_2122110243.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}