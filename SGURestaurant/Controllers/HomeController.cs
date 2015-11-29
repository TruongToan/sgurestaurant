using SGURestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SGURestaurant.Controllers
{
    public class HomeController : Controller
    {
        private SGURestaurantContext db = new SGURestaurantContext();

        //public ActionResult Index()
        //{
        //    var meals = db.Meals;
        //    return View(meals.ToList());
        //}

        public ActionResult Index(string Id)
        {
            var keyword = Request["keyword"];
            var group = Request["group"];
            var price1 = Request["price1"] == null ? 0 : int.Parse(Request["price1"]);
            var price2 = Request["price2"] == null ? 1000 : int.Parse(Request["price2"]);

            if (keyword == null) keyword = "";
            if (group == null) group = "";

            List<MealType> types = db.Meals.Select(e => e.MealType).Distinct().ToList();
            ViewData["groups"] = types;
            if (Id == null || Id.Equals(""))
            {
                ViewBag.Type = string.Empty;
                if (group == "indredients")
                {
                    return View(db.Meals.Where(
                        e => e.Status 
                        && e.Price <= price2 * 1000 
                        && e.Price >= price1 * 1000 
                        && e.Indredients.Contains(keyword)).ToList());
                }
                else if (group == "name")
                {
                    return View(db.Meals.Where(
                        e => e.Status 
                        && e.Price <= price2 * 1000 
                        && e.Price >= price1 * 1000 
                        && e.Name.Contains(keyword)).ToList());
                }
                else
                {
                    return View(db.Meals.Where(
                        e => e.Status 
                        && e.Price <= price2 * 1000 
                        && e.Price >= price1 * 1000 
                        && (e.Name.Contains(keyword) || e.Indredients.Contains(keyword))).ToList());
                }
            }
            else
            {
                ViewBag.Type = Id;
                if (group == "indredients")
                {
                    return View(db.Meals.Where(
                        e => e.Status
                        && e.Price <= price2 * 1000 
                        && e.Price >= price1 * 1000
                        && e.MealType.Name == Id
                        && e.Indredients.Contains(keyword)).ToList());
                }
                else if (group == "name")
                {
                    return View(db.Meals.Where(
                        e => e.Status
                        && e.Price <= price2 * 1000 
                        && e.Price >= price1 * 1000
                        && e.MealType.Name == Id 
                        && e.Name.Contains(keyword)).ToList());
                }
                else
                {
                    return View(db.Meals.Where(
                        e => e.Status 
                        && e.Price <= price2 * 1000 
                        && e.Price >= price1 * 1000
                        && e.MealType.Name == Id 
                        && (e.Name.Contains(keyword) || e.Indredients.Contains(keyword))).ToList());
                }
            }
        }

        public ActionResult Sale()
        {
            List<MealType> types = db.Meals.Select(e => e.MealType).Distinct().ToList();
            return View(db.Meals.Where(e => e.Status && e.Price < e.OriginPrice).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Info(int? id)
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

        public ActionResult Contact()
        {
            var model = new ContactModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                string smtpUserName = "thlogn@gmail.com";
                string smtpPassword = "dvhmmbnspexgspsr";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;

                string emailTo = "thanhlong.itsgu@gmail.com"; // Khi có liên hệ sẽ gửi về thư của mình
                string subject = model.Subject;
                string body = string.Format("Bạn vừa nhận được liên hệ từ: <b>{0}</b><br/>Email: {1}<br/>Nội dung: </br>{2}",
                    model.UserName, model.Email, model.Message);

                EmailService service = new EmailService();

                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "Cảm ơn bạn đã liên hệ với chúng tôi.");
                else ModelState.AddModelError("", "Gửi tin nhắn thất bại, vui lòng thử lại.");
            }
            return View(model);
        }
    }
}