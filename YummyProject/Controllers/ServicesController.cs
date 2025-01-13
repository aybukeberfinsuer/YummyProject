using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        YummyContext _context= new YummyContext();
        public ActionResult Index()
        {
            var values= _context.Services.ToList();
            return View(values);
        }


		[HttpGet]
		public ActionResult Update(int id)
		{
			var value = _context.Services.Find(id);
			return View(value);

		}

		[HttpPost]
		public ActionResult Update(Models.Service model)
		{

			var value = _context.Services.Find(model.ServiceId);
			
			value.Title = model.Title;
			value.Description = model.Description;
			value.Icon = model.Icon;

			if (!ModelState.IsValid)
			{
				return View(model);
			}
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Delete(int id)
		{
			var count = _context.Services.Count();
			if (count > 3)
			{
				var deleted_value = _context.Services.Find(id);
				_context.Services.Remove(deleted_value);
				_context.SaveChanges();

			}
			else
			{
				TempData["ErrorMessage"] = "You have to left min 3 events.";

			}
			return RedirectToAction("Index");
		}



	}
}