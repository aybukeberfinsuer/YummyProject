using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class DashboardController : Controller
    {
       YummyContext _context= new YummyContext();

        public ActionResult Index()
        {

            ViewBag.SoupCount = _context.Products.Count(x => x.Category.CategoryName == "Soup");
            ViewBag.MostExpensive = _context.Products.OrderByDescending(x=>x.Price).Select(x=>x.Productname).FirstOrDefault();
            ViewBag.AveragePrice = _context.Products.Average(x => x.Price);
            ViewBag.CheapestPrice=_context.Products.OrderBy(x=>x.Price).Select(x=>x.Productname).FirstOrDefault();
            return View();
        }
    }
}