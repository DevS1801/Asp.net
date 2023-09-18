using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001215731_LeBuiThienDuc_Tuan1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public string Index2()
        {
            return "ID = " + Request.QueryString["id"] + "name = " + Request.QueryString["name"];
        }
        public ActionResult index3()
        {
            ViewBag.id = Request.QueryString["id"];
            ViewBag.name = Request.QueryString["name"];
            return View();
        }
	}
}