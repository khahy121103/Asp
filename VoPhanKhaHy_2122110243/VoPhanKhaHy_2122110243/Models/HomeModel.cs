using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoPhanKhaHy_2122110243.Context;

namespace VoPhanKhaHy_2122110243.Models
{
    public class HomeModel
    {
        public List<Product> ListProducts { get; set; }
        public List<Category> ListCategories { get; set; }
    }
} 