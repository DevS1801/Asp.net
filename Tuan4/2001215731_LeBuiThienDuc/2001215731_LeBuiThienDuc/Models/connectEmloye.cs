using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;

namespace _2001215731_LeBuiThienDuc.Models
{
    public class connectEmloye
    {
        public string constr = ConfigurationManager.ConnectionStrings["connect1"].ConnectionString;
        public List<Employe> getData()
        {
           List< Employe>  listeml = new List<Employe>();
           SqlConnection con = new SqlConnection(constr);
           SqlCommand cmd = new SqlCommand("select *from tbl_Employee", con);
           cmd.CommandType = CommandType.Text;
           con.Open();

               SqlDataReader rd = cmd.ExecuteReader();
               while(rd.Read())
               {
                   Employe eml = new Employe();
                   eml.Id = int.Parse(rd.GetValue(0).ToString());
                   eml.Name = rd.GetValue(1).ToString();
                   eml.Gender = rd.GetValue(2).ToString();
                   eml.City = rd.GetValue(3).ToString();
                   listeml.Add(eml);
               }
               con.Close();
               return listeml; 
        }
        public int getSL()
        {
             List< Employe>  listeml = new List<Employe>();
           SqlConnection con = new SqlConnection(constr);
           SqlCommand cmd = new SqlCommand("select count(*)from tbl_Employee", con);
           cmd.CommandType = CommandType.Text;
           con.Open();
           int sl = (int)cmd.ExecuteScalar();
           con.Close();
           return sl;
        }
        //insert nv
        public int insert(string name, string gender, string city,int deptid)
        {
            SqlConnection con = new SqlConnection(constr);
            int rs = 0;
            con.Open();
            //kiem tra trung ten
            string sql1 = "select count(*) from tbl_Employee where Name='" + name + "'";
            SqlCommand cmd1= new SqlCommand(sql1, con);
            int kt= (int)cmd1.ExecuteScalar();
            if(kt==0)
            {
                string sql = "insert into tbl_Employee(Name,Gender,City,DeptId)";
            
                sql += "values(N'" + name + "',N'" + gender + "',N'" + city + "','" + deptid + "')";
                SqlCommand cmd=new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                rs=cmd.ExecuteNonQuery();
            }    

            con.Close();
            return rs;
        }
    }
}