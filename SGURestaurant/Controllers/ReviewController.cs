using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGURestaurant.Models;

namespace SGURestaurant.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private SGURestaurantContext db = new SGURestaurantContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rate,Comment,MealId,UserId")] Review review, string returnUrl)
        {

            var currentUser = db.Users.Where(e => e.UserName == User.Identity.Name).First();
            review.UserId = currentUser.Id;
            review.Time = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Votes.Add(review);
                db.SaveChanges();
            }

            return Redirect(returnUrl);
        }
    }
}
