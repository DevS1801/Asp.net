using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai2.Controllers
{
    public class KhoaController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            Models.KhoaModel khoa = new Models.KhoaModel();
            khoa.message = "HUIT- Nang Dong- Sang Tao";
            return View(khoa);
        }
	}
}