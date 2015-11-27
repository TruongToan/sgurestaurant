using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGURestaurant.Models
{
    public class Review
    {
        public virtual int Id { get; set; }

        [Display(Name = "Điểm đánh giá")]
        public virtual float Rate { get; set; }

        [Display(Name = "Bình luận")]
        public virtual string Comment { get; set; }

        [Display(Name = "Thời gian")]
        public virtual DateTime Time { get; set; }

        public virtual int MealId { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}