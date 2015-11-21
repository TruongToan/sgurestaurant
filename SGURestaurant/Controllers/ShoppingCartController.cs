using SGURestaurant.Models;
using SGURestaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGURestaurant.Controllers
{
    public class ShoppingCartController : Controller
    {
        SGURestaurantContext db = new SGURestaurantContext();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var items = new List<CartItemViewModel>();
            foreach (var item in ShoppingCart.Instance.Items)
            {
                CartItemViewModel newItem = new CartItemViewModel();
                newItem.Meal = db.Meals.First(e => e.Id == item.ItemId);
                newItem.Quantity = item.Quantity;
                items.Add(newItem);
            }
            return View(items.ToList());
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            ShoppingCart.Instance.AddToCart(id);
            return Json(ShoppingCart.Instance.GetSubTotal());
        }

        [HttpPost]
        public ActionResult UpdateCart(int id)
        {
            var value = int.Parse(Request["item.Quantity"]);
            ShoppingCart.Instance.SetItemQuantity(id, value);
            return RedirectToAction("Index", "ShoppingCart");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            ShoppingCart.Instance.RemoveFromCart(id);
            return RedirectToAction("Index", "ShoppingCart");
        }

        [HttpPost]
        public ActionResult ClearCart()
        {
            ShoppingCart.Instance.ClearCart();
            return RedirectToAction("Index", "Home");
        }
    }
}