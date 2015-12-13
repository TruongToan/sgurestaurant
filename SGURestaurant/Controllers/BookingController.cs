using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGURestaurant.Models;
using SGURestaurant.ViewModels;

namespace SGURestaurant.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private SGURestaurantContext db = new SGURestaurantContext();

        // GET: Booking
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Bookings.Where(e => User.Identity.Name.Equals(e.User.UserName)).Include(b => b.Table).Include(b => b.User));
        }

        [HttpPost]
        public ActionResult GetBookedTables()
        {
            var date = DateTime.Parse(string.Format("{0:dd/mm/yyyy}", Request["date"]));
            var bookedtables = db.Bookings.Where(e => e.Time == date).Select(e => new { id = e.Table.Id });
            return Json(bookedtables);
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
        
        public ActionResult Create()
        {
            var booking = new Booking();
            var bookingdetails = new List<BookingDetail>();

            foreach (var item in ShoppingCart.Instance.Items)
            {
                BookingDetail newItem = new BookingDetail();
                newItem.Meal = db.Meals.First(e => e.Id == item.ItemId);
                newItem.Number = item.Quantity;
                bookingdetails.Add(newItem);
            }
            booking.BookingDetails = bookingdetails;
            return View(booking);
        }

        [HttpPost]
        public ActionResult Confirm([Bind(Include = "Time,TableId")] Booking booking)
        {
            var currentUser = db.Users.Where(e => e.UserName == User.Identity.Name).FirstOrDefault();
            if (currentUser != null)
            {
                booking.UserId = currentUser.Id;
                booking.Status = false;

                var bookingdetails = new List<BookingDetail>();

                foreach (var item in ShoppingCart.Instance.Items)
                {
                    BookingDetail newItem = new BookingDetail();
                    newItem.Meal = db.Meals.First(e => e.Id == item.ItemId);
                    newItem.Number = item.Quantity;
                    bookingdetails.Add(newItem);
                }
                booking.BookingDetails = bookingdetails;

                if (ModelState.IsValid)
                {
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                    ShoppingCart.Instance.ClearCart();
                    return RedirectToAction("Index");
                }

                ViewBag.TableId = new SelectList(db.Tables, "Id", "Feature", booking.TableId);
            }
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FullName", booking.UserId);
            return RedirectToAction("Index");
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.TableId = new SelectList(db.Tables, "Id", "Feature", booking.TableId);
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FullName", booking.UserId);
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Time,Status,TableId,UserId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TableId = new SelectList(db.Tables, "Id", "Feature", booking.TableId);
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FullName", booking.UserId);
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
