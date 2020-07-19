using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eCommerce.Models;
using System.Data.SqlClient;
using System.Data;

namespace eCommerce.Controllers
{
    public class SellerController : Controller
    {
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\source\repos\ECommG\eCommerce\Ecomm.mdf;Integrated Security=True;Connect Timeout=30";

        SellerDetail Sellers = new SellerDetail();
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SellerDashboard()
          {
            string result;
            if ((HttpContext.Session.GetString("id") != null))
            {
                result = "SellerDashboard";
            }
            else
            {
                //result = "../Login/Login";
                result = "../Login/Login";

            }

            return View(result);
        }

       
        [HttpGet]
        public ActionResult SellerDetail()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult SellerDetail( SellerDetail Sellers)
        {

            //if (HttpContextAccessor.HttpContext.Session.GetString("id") != null)
            //{

            //}
            //Insert_sellerdetails(Sellers);


            Signup s2 = new Signup();
            Login L = new Login();

            var Id = HttpContext.Session.GetString("id");
            L.id = Convert.ToInt32(Id);
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Insert_SellerDetails", con);
                con.Open();
                if (ModelState.IsValid)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", L.id);
                    cmd.Parameters.AddWithValue("@SellerName", Sellers.SellerName);
                    cmd.Parameters.AddWithValue("@Address", Sellers.Address);
                    cmd.Parameters.AddWithValue("@Pincode", Sellers.Pincode);
                    cmd.Parameters.AddWithValue("@BusinessName", Sellers.BusinessName);
                    cmd.Parameters.AddWithValue("@City", Sellers.City);
                    cmd.Parameters.AddWithValue("@State", Sellers.State);
                    cmd.Parameters.AddWithValue("@Country", Sellers.Country);
                    //cmd.Parameters.AddWithValue("@accountType", s2.AccountType);
                    //cmd.Parameters.AddWithValue("@name", m2.name);
                    //cmd.Parameters.AddWithValue("@value", m2.value);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }


            }






          //return RedirectToAction("SellerDashboard", Sellers);
            return View();
        }

        public ActionResult Seller()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("../Login/Login");
        }
       

     
        //public string Insert_sellerdetails(SellerDetail Sellers)
        //{
            //var Id = HttpContext.Session.GetString("id");
            //L.id = Convert.ToInt32(Id);
            //using (SqlConnection con = new SqlConnection(connectionstring))
            //{
            //    SqlCommand cmd = new SqlCommand("Insert_SellerDetails", con);
            //        con.Open();
            //    if (ModelState.IsValid)
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Id", L.id);
            //        cmd.Parameters.AddWithValue("@SellerName", Sellers.SellerName);
            //        cmd.Parameters.AddWithValue("@Address", Sellers.Address);
            //        cmd.Parameters.AddWithValue("@Pincode", Sellers.Pincode);
            //        cmd.Parameters.AddWithValue("@BusinessName", Sellers.BusinessName);
            //        cmd.Parameters.AddWithValue("@City", Sellers.City);
            //        cmd.Parameters.AddWithValue("@State", Sellers.State);
            //        cmd.Parameters.AddWithValue("@Country", Sellers.Country);
            //        //cmd.Parameters.AddWithValue("@accountType", s2.AccountType);
            //        //cmd.Parameters.AddWithValue("@name", m2.name);
            //        //cmd.Parameters.AddWithValue("@value", m2.value);
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }

                
            //}
        //    return ("Success");

        //}
    }
}