using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai2_DangNhap.Controllers
{
    public class DangNhapController : Controller
    {
        //
        // GET: /DangNhap/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string Name, string pass)
        {
            if ("thienduc".Equals(Name) && "123456".Equals(pass))
            {
                Session["user"] = new Models.User() { login = Name, userName = "THiên Đức" };
               
            }
            return RedirectToAction("Index", "Home");
            
        }
         [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
          [HttpPost]
         public ActionResult DangKy(string name, string pass, string rtpass)
         {
              if(name.Length>=5&&pass.Length>=6&&rtpass.Equals(pass))
              {
                  return RedirectToAction("DangNhap", "DangNhap");
              }
              else
                    return View();
         }

        public ActionResult DangXuat()
          {
              Session.Clear();
              return RedirectToAction("DangNhap", "DangNhap");
          }
	}
}