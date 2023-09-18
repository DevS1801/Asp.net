using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _2001215731_LeBuiThienDuc.Models;
using System.Data;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Web.Caching;

namespace _2001215731_LeBuiThienDuc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Erro()
        {
            return View();
        }
        public ActionResult show()
        {
            List<Employe> listeml = new List<Employe>();
            try
            {
                using(SqlConnection con= new SqlConnection())
                {
                    string constr= ConfigurationManager.ConnectionStrings["connect1"].ConnectionString;
                    con.ConnectionString=constr;
                    string sql = "select *from tbl_Employee";
                    DataTable dt =new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql,con);
                    da.Fill(dt);
                    foreach(DataRow item in dt.Rows)
                    {
                        var eml = new Employe();
                        eml.Id = (int)item["Id"];
                        eml.Name = item["Name"].ToString();
                        eml.Gender = item["Gender"].ToString();
                        eml.City = item["City"].ToString();
                        listeml.Add(eml);
                    }

                }
                return View(listeml);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Erro","Home");
            }
           
        }

         public ActionResult show1()
        {
            connectEmloye obj = new connectEmloye();
            List<Employe> listeml = obj.getData();
            ViewBag.Soluong = obj.getSL();
            return View(listeml);
        }

        public ActionResult showDepar()
        {
            connectDeparment obj = new connectDeparment();
            List<Deparment> listDepa = obj.getData();
            
            return View(listDepa);
        }
        public ActionResult Details(string id)
        {
            connectDeparment obj = new connectDeparment();
            Deparment deparment = obj.Details(id.ToString());
            ViewBag.getSoNV = obj.getSNV(id);
            if (deparment == null)
            {
                return HttpNotFound(); 
            }

            return View(deparment);
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(FormCollection fc)
        {
            connectEmloye obj=new connectEmloye();
            var name = fc["Fullname"];
            var gender = fc["Gender"];
            var city = fc["City"];
            var deptid = int.Parse(fc["DeptId"]);
            int kt=obj.insert(name,gender,city,deptid);
            if (kt == 0)
            {
                ViewBag.ThongBao = "Thêm Không Thành Công";
            }
            else
                ViewBag.ThongBao = "Thêm Thành Công";
            return View();
        }

    }
}