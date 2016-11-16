using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page1()
        {
            Debug.WriteLine(Request.RawUrl);
            Debug.WriteLine(Request.HttpMethod);
            Debug.WriteLine(Request.QueryString);
            Debug.WriteLine("Congratulations! You have created a new account.");
            Debug.WriteLine("Your username is " + Request.QueryString["itemA"]);
            Debug.WriteLine("Your password is " + Request.QueryString["itemB"]);
            return View();
        }

        [HttpGet]
        public ActionResult Page2()
        {
            Debug.WriteLine("In GET Page2");
            ShowRequest();
            return View();
        }

        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            Debug.WriteLine("In POST Page2");
            ShowRequest();
            ViewBag.message = "Congratulations! You have created a new account. Your username is " + form["username"] + ". Your password is " + form["password"] + ".";
            return View();
        }

        [HttpGet]
        public ActionResult Page3()
        {
            Debug.WriteLine("In GET Page2");
            ShowRequest();
            return View();
        }

        [HttpPost]
        public ActionResult Page3(FormCollection form)
        {
            Debug.WriteLine("In POST Page2");
            ShowRequest();
            double monthly = Convert.ToDouble(form["loan"]) * Convert.ToDouble(form["rate"]) * Math.Pow((Convert.ToDouble(form["rate"]) + 1), Convert.ToDouble(form["length"])) / (Math.Pow((Convert.ToDouble(form["rate"]) + 1), Convert.ToDouble(form["length"])) - 1);
            double sum = monthly * Convert.ToDouble(form["length"]);
            ViewBag.message = "The monthly payment is " + String.Format("{0:F}", monthly) + " and the sum of payments is " + String.Format("{0:F}", sum) + ".";
            return View();
        }

        private void ShowRequest()
        {
            Debug.WriteLine("\t" + Request.RawUrl);
            Debug.WriteLine("\t" + Request.HttpMethod);
            Debug.WriteLine("\tForm Data:");
            NameValueCollection d = Request.Form;
            foreach (string key in d.AllKeys)
            {
                Debug.WriteLine("\t {0} : {1}", key, d[key]);
            }
        }
    }
}