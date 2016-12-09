using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Training.Programming.FinalTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             ViewBag.Message = "Hello! Do You need insurance? We can sell to you";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hello! Do You need insurance? We can sell to you";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}