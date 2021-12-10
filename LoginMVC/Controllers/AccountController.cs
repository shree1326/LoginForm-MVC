using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;
using System.Data.SqlClient;

namespace LoginMVC.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void cs()
        { 
            
          con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CodeFirstEFDB;Integrated Security=True";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            cs();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username='"+acc.Name+"' and password='"+acc.Password+"'" ;
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            
           
        }
    }
}