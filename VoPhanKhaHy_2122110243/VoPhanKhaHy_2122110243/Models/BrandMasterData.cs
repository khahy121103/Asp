﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace VoPhanKhaHy_2122110243.Models
{
    public class BrandMasterData
    {
        public int Id { get; set; }

        [Display(Name = "Tên thương hiệu")]
        public string Name { get; set; }

        [Display(Name = "Ảnh thương hiệu")]
        public string Avartar { get; set; }

        [Display(Name = "Slug")]
        public string Slug { get; set; }

        [Display(Name = "Hiển thị trên trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public Nullable<int> DisplayOrder { get; set; }

        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }

        [Display(Name = "Đã xóa")]
        public Nullable<bool> Deleted { get; set; }

        [NotMapped]
        [Display(Name = "Tải ảnh")]
        public HttpPostedFileBase ImageUpLoad { get; set; }
    }
}
