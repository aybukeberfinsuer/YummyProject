using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class TestimonialsController : Controller
    {
        // GET: Testimonials
        YummyContext _context = new YummyContext();

        public ActionResult Index()
        {            
            return View(_context.Testimonials.ToList());
        }

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Testimonial tstml)
		{
			if (!ModelState.IsValid)
			{
				return View(tstml);
			}
			_context.Testimonials.Add(tstml);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var count = _context.Testimonials.Count();
			if (count > 3)
			{
				var deleted_value = _context.Testimonials.Find(id);
				_context.Testimonials.Remove(deleted_value);
				_context.SaveChanges();

			}
			else
			{
				TempData["ErrorMessage"] = "You have to left min 3 comment.";

			}
			return RedirectToAction("Index");
		}




		[HttpGet]
		public ActionResult Update(int id)
		{
			var value = _context.Testimonials.Find(id);
			return View(value);

		}

		[HttpPost]
		public ActionResult Update(Testimonial model)
		{

			var value = _context.Testimonials.Find(model.TestimonialId);
			value.ImageUrl = model.ImageUrl;
			value.NameSurname = model.NameSurname;
			value.Title = model.Title;
			value.Comment = model.Comment;
			value.Rating = model.Rating;
			

			if (!ModelState.IsValid)
			{
				return View(model);
			}
			_context.SaveChanges();
			return RedirectToAction("Index");
		}


	}
}