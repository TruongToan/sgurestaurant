using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SGURestaurant.Models
{
    public class DialyMenu
    {
        [DisplayName("Mã số")]
        public virtual int Id { get; set; }

        [DisplayName("Ngày")]
        public virtual DateTime Date { get; set; }

        [DisplayName("Danh mục món ăn")]
        public virtual List<Meal> Meals { get; set; }
    }
}