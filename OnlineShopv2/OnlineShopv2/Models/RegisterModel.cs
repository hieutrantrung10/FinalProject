﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace OnlineShopv2.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "つ ◕_◕ ༽つ Bạn không được để trống tên đăng nhập")]
        public string UserName { set; get; }
        [Display(Name = "Mật khẩu")]
        [StringLength(500, MinimumLength = 6, ErrorMessage = "つ ◕_◕ ༽つ Bạn cần nhập mật khẩu có độ dài lớn hơn 6 ký tự")]
        [Required(ErrorMessage = "つ ◕_◕ ༽つ Bạn không được để trống mật khẩu")]
        public string Password { set; get; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "つ ◕_◕ ༽つ Xác nhập lại sai mật khẩu")]
        [Required(ErrorMessage = "つ ◕_◕ ༽つ Bạn chưa nhập lại mật khẩu")]
        public string ConfirmPassword { set; get; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "つ ◕_◕ ༽つ Bạn không được để trống họ tên")]
        public string Name { set; get; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "つ ◕_◕ ༽つ Bạn không được để trống địa chỉ")]
        public string Address { set; get; }
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "つ ◕_◕ ༽つ Hãy nhập lại địa chỉ Email")]
        public string Email { set; get; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "つ ◕_◕ ༽つ Bạn không được để trống số điện thoại")]
        public string Phone { set; get; }

    }
}