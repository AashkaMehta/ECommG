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

        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\source\repos\ECommG\eCommerce\Ecomm.mdf;Integrated Security=True;Connect Timeout=30";
        string username = string.Empty;
        string password = string.Empty;
        Login L = new Login();
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
            //return View();
            if (add_emp(s) == null)
            {
                //return RedirectToAction("Login");
                return View();

            }
            //return View();
            return RedirectToAction("Login");

        }


        public string add_emp(Signup s2)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                if (ModelState.IsValid)
                {
                    SqlCommand cmd = new SqlCommand("GetData_Signup", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstName", s2.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", s2.LastName);
                    cmd.Parameters.AddWithValue("@email", s2.Email);
                    cmd.Parameters.AddWithValue("@password", s2.Password);
                    cmd.Parameters.AddWithValue("@Mobnumber", s2.MobNumber);
                    //cmd.Parameters.AddWithValue("@accountType", s2.AccountType);
                    //cmd.Parameters.AddWithValue("@name", m2.name);
                    //cmd.Parameters.AddWithValue("@value", m2.value);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return ("Success");

        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();  
        }
        

        [HttpPost]
        public ActionResult Login([Bind] Login L)
        {
            string result;


            SqlConnection con = new SqlConnection(connectionstring);


            con.Open();

            SqlCommand cmd = new SqlCommand("validate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", L.Email);
            cmd.Parameters.AddWithValue("@Password", L.Password);
            
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                      
                        HttpContext.Session.SetString("id", rdr["id"].ToString());
                        
                        //var Id=HttpContext.Session.GetString( "id");
                        //L.id = Id;
                        HttpContext.Session.SetString("Firstname", rdr["Firstname"].ToString());

                    }
                    //result = "../Seller/SellerDashboard";
                    //return View();
                    return RedirectToAction("../Seller/SellerDashboard");
                }
                else
                {
                    //result = "error";
                    ViewBag.Message = "Error";
                    return RedirectToAction("../Login/Login");

                }
            }
            con.Close();

            return Json(result);


            
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("../Login/Login");
        }

    }
}