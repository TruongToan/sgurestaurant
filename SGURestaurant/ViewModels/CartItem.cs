using SGURestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGURestaurant.ViewModels
{
    public class CartItem : IEquatable<CartItem>
    {
        public int Quantity { get; set; }
        public int ItemId { get; set; }

        public CartItem(int Id)
        {
            this.ItemId = Id;
            this.Quantity = 0;
        }

        public bool Equals(CartItem item)
        {
            return ItemId == item.ItemId;
        }
    }
}