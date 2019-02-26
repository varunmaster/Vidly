using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is my application about page. I have no " +
            	"idea what I'm doing.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact me on my phone at 911.";

            return View();
        }
    }
}