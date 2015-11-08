using SGURestaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGURestaurant.ViewModels
{
    public class CartItemViewModel
    {
        public Meal Meal { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
    }
}