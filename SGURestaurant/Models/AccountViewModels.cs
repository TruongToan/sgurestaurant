using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SGURestaurant.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Số ĐT")]
        [StringLength(50, ErrorMessage = "{0} không được quá {1} ký tự")]
        [Phone(ErrorMessage = "{0} không hợp lệ")]
        public string PhoneNumber { get; set; }
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
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ mật khẩu?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [EmailAddress(ErrorMessage = "{0} không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [StringLength(100, ErrorMessage = "{0} tối thiểu {2} ký tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "{0} không đúng")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Họ tên")]
        [StringLength(50, ErrorMessage = "{0} không được quá {1} ký tự")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Số ĐT")]
        [StringLength(50, ErrorMessage = "{0} không được quá {1} ký tự")]
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

    //public class AccountModels
    //{
    //    public string Email { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public string UserName { get; set; }
    //    SGURestaurantContext db = new SGURestaurantContext();
    //    public List<AccountModels> findAll()
    //    {
    //        List<AccountModels> listUsers = db.Users.Take(10).ToList();

    //        return listUsers;
    //    }
    //}
}
