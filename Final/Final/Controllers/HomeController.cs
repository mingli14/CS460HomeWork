using Final.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private FinalContext db = new FinalContext();

        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public JsonResult Generate(string a)
        //{
        //    //db.Genres.Where(b => b.Name == a).FirstOrDefault().ID
        //    //var table = db.Classifications.Where(c => c.GenreID == db.Genres.Where(b => b.Name == a).FirstOrDefault().ID).GroupJoin(d => d.);

        //    //   var table = db.Crews.GroupBy(c => c.PirateID).Select(p => new { PName = p.Key, TotalBooty = p.Sum(b => b.Booty) }).OrderByDescending(c => c.TotalBooty).ToList();
        //    //string[] name = new string[table.Count];
        //    //decimal[] totalBooty = new decimal[table.Count];
        //    //for (int i = 0; i < table.Count; i++)
        //    //{
        //    //    name[i] = db.Pirates.Find(table[i].PName).Name;
        //    //    totalBooty[i] = table[i].TotalBooty;
        //    //}
        //    //var data = new
        //    //{
        //    //    Message = "Hello from controller action method",
        //    //    name = name,
        //    //    totalBooty = totalBooty,
        //    //    count = name.Length

        //    //};
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
    }
}