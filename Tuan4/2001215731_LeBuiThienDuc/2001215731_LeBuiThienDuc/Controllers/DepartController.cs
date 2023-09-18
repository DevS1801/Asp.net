using _2001215731_LeBuiThienDuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001215731_LeBuiThienDuc.Controllers
{
    public class DepartController : Controller
    {
        // GET: Depart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult showDDl() {
            connectDeparment obj= new connectDeparment();
            List<Deparment> list = obj.getData();
            return View(list);
        }
        public ActionResult showlstEml(string id)
        { 
            connectDeparment obj= new connectDeparment();
            Deparment depa = obj.Details(id);
            List<Employe> lst=obj.listEmlbyDeptId(id);
            ViewBag.eml=lst;
            return View(depa);
        }
    }
}