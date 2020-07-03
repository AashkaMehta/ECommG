using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Data.SqlClient;
using System.Data;

namespace eCommerce.Controllers
{
    public class LoginController : Controller
    {

        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\Ecomm.mdf;Integrated Security=True;Connect Timeout=30";
        string username = string.Empty;
        string password = string.Empty;

        Signup s2 = new Signup();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Signup()
        {
            ViewBag.Message = HttpContext.Session.GetString("Email");
            return View();
        }
        [HttpPost]
        public IActionResult Signup([Bind] Signup s)
        {
           add_emp(s);
            return View();
        }
       

        public string add_emp(Signup s2)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetData_Signup", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstname", s2.FirstName);
                cmd.Parameters.AddWithValue("@lastname", s2.LastName);
                cmd.Parameters.AddWithValue("@email", s2.Email);
                cmd.Parameters.AddWithValue("@password", s2.Password);
                cmd.Parameters.AddWithValue("@Mobnumber", s2.MobNumber);
                //cmd.Parameters.AddWithValue("@name", m2.name);
                //cmd.Parameters.AddWithValue("@value", m2.value);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            return ("Success");

        }

        [HttpGet]
        public ActionResult Login(Login login)
        {
            return View();  
        }
        

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            string result;


            SqlConnection con = new SqlConnection(connectionstring);


            con.Open();

            SqlCommand cmd = new SqlCommand("validate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        HttpContext.Session.SetString("id", rdr["id"].ToString());
                        HttpContext.Session.SetString("firstname", rdr["firstname"].ToString());

                    }
                    result = "success";
                }
                else
                {
                    result = "error";

                }
            }
            con.Close();

            return Json(result);


            
        }
    
    }
}