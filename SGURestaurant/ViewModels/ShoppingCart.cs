using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGURestaurant.ViewModels
{
    public class ShoppingCart
    {
        private const string mSessionName = "SGURestaurantShoppingCart";

        public IList<CartItem> Items { get; private set; }

        public static readonly ShoppingCart Instance;

        static ShoppingCart()
        {
            if (HttpContext.Current.Session[mSessionName] == null)
            {
                Instance = new ShoppingCart();
                Instance.Items = new List<CartItem>();
                HttpContext.Current.Session[mSessionName] = Instance;
            }
            else
            {
                Instance = (ShoppingCart)HttpContext.Current.Session[mSessionName];
            }
        }

        // Add protected contructer to prevent create this class
        protected ShoppingCart() { }

        // Add to cart
        public void AddToCart(int id)
        {
            CartItem newItem = new CartItem(id);

            if (Items.Contains(newItem))
            {
                foreach (var item in Items)
                    if (newItem.Equals(item))
                    {
                        item.Quantity++;
                        return;
                    }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }
        }

        // Set item quantity
        public void SetItemQuantity(int id, int quantity)
        {
            CartItem updateItem = new CartItem(id);
            foreach (var item in Items)
                if (updateItem.Equals(item))
                {
                    item.Quantity = quantity;
                    return;
                }
        }

        // Remove item form cart
        public void RemoveFromCart(int id)
        {
            CartItem deleteItem = new CartItem(id);
            Items.Remove(deleteItem);
        }

        // Remove item form cart
        public void ClearCart()
        {
            Items.Clear();
        }

        // Get total
        public int GetSubTotal()
        {
            int total = 0;
            foreach (var item in Items)
            {
                total += 1;
            }
            return total;
        }
    }
}