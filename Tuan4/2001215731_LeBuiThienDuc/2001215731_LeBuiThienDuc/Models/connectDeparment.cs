using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace _2001215731_LeBuiThienDuc.Models
{
    public class connectDeparment
    {
        public string constr = ConfigurationManager.ConnectionStrings["connect1"].ConnectionString;
        public List<Deparment> getData()
        {
            List<Deparment> listDepa = new List<Deparment>();
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select *from tbl_Deparment", con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Deparment depa = new Deparment();
                depa.Id = int.Parse(rd.GetValue(0).ToString());
                depa.Name = rd.GetValue(1).ToString();

                listDepa.Add(depa);
            }
            con.Close();
            return listDepa;

        }
        public int getSNV(string id)
        {
            int ma = int.Parse(id);
          
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select count(tbl_Employee.Id) from tbl_Deparment,tbl_Employee where tbl_Deparment.DeptId=tbl_Employee.DeptId and tbl_Deparment.DeptId=@MaPB", con);
            cmd.CommandType = CommandType.Text;

            SqlParameter par=cmd.CreateParameter();
            par.ParameterName = "@MaPB";
            par.Value = ma;
            cmd.Parameters.Add(par);
            con.Open();

            int sl = (int)cmd.ExecuteScalar();
            con.Close();
            return sl;

        }

        public Deparment Details(string id)
        {
            List<Deparment> listDepa = new List<Deparment>();
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select *from tbl_Deparment", con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Deparment depa = new Deparment();
                depa.Id = int.Parse(rd.GetValue(0).ToString());
                depa.Name = rd.GetValue(1).ToString();

                listDepa.Add(depa);
            }
            int ma = int.Parse(id);
            Deparment d = listDepa.FirstOrDefault(x => x.Id==ma);
            return d;
        }

        //cau 4
        //lay data khoa

        public List<Employe> listEmlbyDeptId(string id)
        {
            int ma=int.Parse(id);
            List<Employe> lst = new List<Employe>();
            SqlConnection con = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand("select*from tbl_Employee where DeptId=@MaPB",con);
            cmd.CommandType = CommandType.Text;
            SqlParameter par = cmd.CreateParameter();
            par.ParameterName = "@MaPB";
            par.Value = ma;
            cmd.Parameters.Add(par);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
               Employe eml= new Employe();
                eml.Id = int.Parse(rd.GetValue(0).ToString());
                eml.Name = rd.GetValue(1).ToString();
                eml.Gender = rd.GetValue(2).ToString();
                eml.City = rd.GetValue(3).ToString();

                lst.Add(eml);
            }
            con.Close();
            return lst;
        }
    }
}