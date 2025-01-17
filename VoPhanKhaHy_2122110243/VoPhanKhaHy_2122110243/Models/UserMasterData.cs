using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoPhanKhaHy_2122110243.Models
{
    public class UserMasterData
    {
        public int Id { get; set; }

        [Display(Name = "Tên người dùng")]
        public string FirstName { get; set; }

        [Display(Name = "Họ người dùng")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Quản trị viên")]
        public Nullable<bool> IsAdmin { get; set; }
    }
}