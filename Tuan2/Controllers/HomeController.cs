using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tuan2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HOME()
        {
            return View();
        }
        public ActionResult ABOUT()
        {
            return View();
        }
        public ActionResult SERVICES()
        {
            return View();
        }
        public ActionResult SUPPORT()
        {
            return View();
        }
        public ActionResult CONTACT()
        {
            return View();
        }

    }
}