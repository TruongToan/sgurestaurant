using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGURestaurant.Models
{
    public class Vote
    {
        public virtual int Id { get; set; }

        [Display(Name = "Điểm đánh giá")]
        public virtual float Score { get; set; }

        [Display(Name = "Bình luận")]
        public virtual String Comment { get; set; }

        public virtual int MealId { get; set; }

        public virtual Meal Meal { get; set; }
    }
}