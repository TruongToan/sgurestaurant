
using System.ComponentModel.DataAnnotations;
namespace SGURestaurant.Models
{
    /// <summary>
    /// Contact Model
    /// </summary>
    public class ContactModel
    {
        [Display(Name = "Tên của bạn")]
        [Required(ErrorMessage = "Tên không được trống")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được trống")]
        [DataType(DataType.EmailAddress, ErrorMessage="Email không đúng")]
        public string Email { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage="Chủ đề không được trống")]
        public string Subject { get; set; }

        [Display(Name = "Nội dung")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}