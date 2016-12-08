using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class ProductsController : Controller
    {
        public int PageCount { get; set; } = 9;

        // GET: Products
        public ActionResult Category(int id, int page = 1)
        {
            using (AdventureWorks2014Context db = new AdventureWorks2014Context())
            {
                ProductSubcategory psc = db.ProductSubcategories.Find(id);
                IEnumerable<Product> products = psc.Products.OrderBy(p => p.Name).Skip((page - 1) * PageCount).Take(PageCount);
                ViewBag.Title = psc.Name;
                ViewBag.ID = id;
                ViewBag.Page = page;
                ViewBag.PageMax = Math.Ceiling(psc.Products.Count() / (double)PageCount);
                return View(products);
            }
        }

        public ActionResult Details(int? id)
        {
            return View();
        }
    }
}