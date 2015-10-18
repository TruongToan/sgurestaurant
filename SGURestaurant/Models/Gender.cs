using System.ComponentModel.DataAnnotations;

namespace SGURestaurant.Models
{
    public enum Gender
    {
        [Display(Name = "Nam")]
        MAN,
        [Display(Name = "Nữ")]
        WOMAN,
        [Display(Name = "Khác")]
        OTHER
    }
}