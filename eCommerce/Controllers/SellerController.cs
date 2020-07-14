using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace eCommerce.Controllers
{
    public class SellerController : Controller
    {
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

        public ActionResult SellerDetail()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("../Login/Login");
        }
    }
}