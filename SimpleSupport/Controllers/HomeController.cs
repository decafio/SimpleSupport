using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleSupport.API;
using System.Threading.Tasks; // Task

namespace SimpleSupport.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Multiplier = await MCSF.AdditionalChildrenMultiplier(2);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}