using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGURestaurant.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Ghi nhớ tài khoản?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ mật khẩu?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "{0} không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} tối thiểu {2} ký tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "{0} không đúng")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Họ tên")]
        [StringLength(50, ErrorMessage = "{0} không được quá {1} ký tự")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        [StringLength(200, ErrorMessage = "{0} không được quá {1} ký tự")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        [Phone(ErrorMessage = "{0} không hợp lệ")]
        public string PhoneNumber { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} tối thiểu ký tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "{0} không đúng")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
