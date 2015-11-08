
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
    public class MealsController : Controller
    {
        private SGURestaurantContext db = new SGURestaurantContext();

        // GET: Meals
        public ActionResult Index()
        {
            var meals = db.Meals.Include(m => m.MealStyle).Include(m => m.MealType);
            return View(meals.ToList());
        }

        // GET: Meals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: Meals/Create
        public ActionResult Create()
        {
            ViewBag.MealStyleId = new SelectList(db.MealStyles, "Id", "Name");
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "Id", "Name");
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Indredients,Price,MealTypeId,MealStyleId,ImageUrl,Status")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Meals.Add(meal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MealStyleId = new SelectList(db.MealStyles, "Id", "Name", meal.MealStyleId);
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "Id", "Name", meal.MealTypeId);
            return View(meal);
        }

        // GET: Meals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            ViewBag.MealStyleId = new SelectList(db.MealStyles, "Id", "Name", meal.MealStyleId);
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "Id", "Name", meal.MealTypeId);
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Indredients,Price,MealTypeId,MealStyleId,ImageUrl,Status")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MealStyleId = new SelectList(db.MealStyles, "Id", "Name", meal.MealStyleId);
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "Id", "Name", meal.MealTypeId);
            return View(meal);
        }

        // GET: Meals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meal meal = db.Meals.Find(id);
            db.Meals.Remove(meal);
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
