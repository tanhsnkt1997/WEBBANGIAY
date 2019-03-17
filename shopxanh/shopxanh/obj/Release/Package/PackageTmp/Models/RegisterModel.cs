using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopxanh.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage = "Yeu cau nhap ten dang nhap")]
       
        public string UserName { set; get; }
        [Display(Name = "Mật Khẩu")]
        [StringLength(20,MinimumLength=6,ErrorMessage ="độ dài mật khẩu ít nhất 6 kí tự.")]
        [Required(ErrorMessage = "Yeu cau nhap mat khau")]
        public string Password { set; get; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { set; get; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yeu cau nhap ho ten")]
        public string Name { set; get; }
        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yeu cau nhap Email")]
        public string Email{ set; get; }
        [Display(Name = "Điện thoại")]
        public string Phone { set; get; }

    }
}