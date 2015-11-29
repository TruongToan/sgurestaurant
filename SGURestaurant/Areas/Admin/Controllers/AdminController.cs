
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace SGURestaurant.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class AdminController : Controller
    {
        SGURestaurant.Models.SGURestaurantContext db = new SGURestaurant.Models.SGURestaurantContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            ViewData["user-count"] = db.Users.Count();
            ViewData["meal-count"] = db.Meals.Count();
            ViewData["booking-count"] = db.Bookings.Count();
            ViewData["income"] = db.BookingDetails.Sum(e => e.Meal.Price * e.Number).ToString("0,000");
            return View();
        }
    }
}