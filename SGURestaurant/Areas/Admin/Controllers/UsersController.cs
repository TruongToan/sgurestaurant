using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGURestaurant.Models;
using Microsoft.AspNet.Identity;
using SGURestaurant.Areas.Admin.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SGURestaurant.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private SGURestaurantContext db = new SGURestaurantContext();
        private ApplicationRoleManager roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(new SGURestaurantContext()));
        private ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new SGURestaurantContext()));

        // GET: Admin/Users
        public ActionResult Index()
        {
            IList<UserViewModel> users = new List<UserViewModel>();
            foreach (ApplicationUser user in db.Users.ToList())
            {
                string userRole = roleManager.FindById(user.Roles.FirstOrDefault().RoleId).Name;
                ViewData["role-" + user.UserName] = new SelectList(db.Roles, "Name", "Name", userRole);
                users.Add(new UserViewModel() {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsActive = user.EmailConfirmed,
                    Role = userRole });
            }
            return View(users);
        }

        [HttpPost]
        public ActionResult Update(string id)
        {
            var newRole = Request["item.Role"];
            if (id != null && newRole != null)
            {
                userManager.RemoveFromRoles(id, userManager.GetRoles(id).ToArray());
                userManager.AddToRole(id, newRole);
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
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
