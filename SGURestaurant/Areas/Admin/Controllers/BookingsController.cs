using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGURestaurant.Models;

namespace SGURestaurant.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager")]
    public class BookingsController : Controller
    {
        private SGURestaurantContext db = new SGURestaurantContext();

        // GET: Admin/Bookings
        public ActionResult Index()
        {
            var view = Request["view"];
            var bookings = db.Bookings.Where(e => !e.Status).Include(b => b.Table).Include(b => b.User);

            if (Request["view"] == "approval")
            {
                bookings = db.Bookings.Where(e => e.Status).Include(b => b.Table).Include(b => b.User);
            }
            else if (Request["view"] == "all")
            {
                bookings = db.Bookings.Include(b => b.Table).Include(b => b.User);
            }
            
            return View(bookings.ToList());
        }

        [HttpPost]
        public ActionResult Approval(int? id)
        {
            if (id != null)
            {
                db.Bookings.SingleOrDefault(e => e.Id == id).Status = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Bookings/Details/5
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

        // GET: Admin/Bookings/Create
        public ActionResult Create()
        {
            ViewBag.TableId = new SelectList(db.Tables, "Id", "Feature");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Address");
            return View();
        }

        // POST: Admin/Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Time,Status,TableId,UserId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TableId = new SelectList(db.Tables, "Id", "Feature", booking.TableId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Address", booking.UserId);
            return View(booking);
        }

        // GET: Admin/Bookings/Edit/5
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
            ViewBag.UserId = new SelectList(db.Users, "Id", "Address", booking.UserId);
            return View(booking);
        }

        // POST: Admin/Bookings/Edit/5
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
            ViewBag.UserId = new SelectList(db.Users, "Id", "Address", booking.UserId);
            return View(booking);
        }

        // GET: Admin/Bookings/Delete/5
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

        // POST: Admin/Bookings/Delete/5
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
