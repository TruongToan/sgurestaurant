using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGURestaurant.Models
{
    public class Meal
    {
        [DisplayName("Mã món")]
        public virtual int Id { get; set; }

        [DisplayName("Tên món")]
        public virtual string Name { get; set; }

        [DisplayName("Nguyên liệu chính")]
        [DataType(DataType.MultilineText)]
        public virtual string Indredients { get; set; }

        [DisplayName("Giá gốc")]
        public virtual int OriginPrice { get; set; }

        [DisplayName("Giá")]
        public virtual int Price { get; set; }

        public virtual int MealTypeId { get; set; }

        [DisplayName("Thứ tự món")]
        public virtual MealType MealType { get; set; }

        public virtual int MealStyleId { get; set; }

        [DisplayName("Kiểu món")]
        public virtual MealStyle MealStyle { get; set; }

        [DisplayName("Ảnh")]
        public virtual string ImageUrl { get; set; }

        public virtual bool Status { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}