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


		public ActionResult Delete(int id)
		{
			var value= _context.Chefs.Find(id);
			if (value != null)
			{
				_context.Chefs.Remove(value);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else {
				return RedirectToAction("Index");
			}


		}


		[HttpGet]
		public ActionResult Update(int id)
		{
			var value= _context.Chefs.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult Update(Chef _chef)
		{
			if (!ModelState.IsValid)
			{
				return View(_chef);
			}
			var value = _context.Chefs.Find(_chef.ChefId);
			value.Name = _chef.Name;
			value.ImageUrl = _chef.ImageUrl;
			value.Title = _chef.Title;
			value.Name = _chef.Name;
			value.Description = _chef.Description;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}


	}
}