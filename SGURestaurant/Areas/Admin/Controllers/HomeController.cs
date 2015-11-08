
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace SGURestaurant.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            ServiceReference1.IService1 service1 = new ServiceReference1.Service1Client();
            ServiceReference2.IService service2 = new ServiceReference2.ServiceClient();
            ViewBag.Result1 = service1.GetData("Toan");
            ViewBag.Result2 = service2.GetData(100);
            return View();
        }
    }
}