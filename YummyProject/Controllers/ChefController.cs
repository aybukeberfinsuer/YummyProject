using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ChefController : Controller
    {
        // GET: Chef
        YummyContext _context= new YummyContext();
        public ActionResult Index()
        {
            var values = _context.Chefs.ToList();
            return View(values);
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Chef _chef)
		{
			if (!ModelState.IsValid)
			{
				return View(_chef);
			}
			_context.Chefs.Add(_chef);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}