using HW8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class BootysController : Controller
    {

        private HW8Context db = new HW8Context();

        // GET: Booty
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Generate the data and give them to the javacript file.
        /// </summary>
        public JsonResult Generate()
        {
            var table = db.Crews.GroupBy(c => c.PirateID).Select(p => new { PName = p.Key, TotalBooty = p.Sum(b => b.Booty) }).OrderByDescending(c => c.TotalBooty).ToList();
            //Create an array to store the name
            string[] name = new string[table.Count];
            //Create an array to store the totalBooty
            decimal[] totalBooty = new decimal[table.Count];
            for (int i = 0; i < table.Count; i++)
            {
                //Store the name in an array
                name[i] = db.Pirates.Find(table[i].PName).Name;
                //Store the totalBooty in an array
                totalBooty[i] = table[i].TotalBooty;
            }
            //Create the data to be returned.
            var data = new
            {
                Message = "Hello from controller action method",
                name = name,
                totalBooty= totalBooty,
                count = name.Length

            };
            //return the data to the javacript file.
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}