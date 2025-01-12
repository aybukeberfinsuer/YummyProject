using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
		YummyContext _context= new YummyContext();
        public ActionResult Index()
        {
            var values= _context.Events.ToList();
			return View(values);
        }


		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Event evnt)
		{
			if (!ModelState.IsValid)
			{
				return View(evnt);
			}
			_context.Events.Add(evnt);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var count= _context.Events.Count();
			if (count > 3)
			{
				var deleted_value = _context.Events.Find(id);
				_context.Events.Remove(deleted_value);
				_context.SaveChanges();				

			}
			else
			{
				TempData["ErrorMessage"] = "You have to left min 3 events.";
				
			}
			return RedirectToAction("Index");
		}



		[HttpGet]
		public ActionResult Update(int id)
		{
			var value = _context.Events.Find(id);
			return View(value);

		}

		[HttpPost]
		public ActionResult Update(Event model)
		{

			var value = _context.Events.Find(model.EventId);
			value.ImageUrl = model.ImageUrl;
			value.Title = model.Title;
			value.Description = model.Description;
			value.Price = model.Price;

			if (!ModelState.IsValid)
			{
				return View(model);
			}
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}