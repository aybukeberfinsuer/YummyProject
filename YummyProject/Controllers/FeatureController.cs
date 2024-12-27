using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class FeatureController : Controller
    {
        YummyContext _context= new YummyContext();
        public ActionResult Index()
        {
           var values= _context.Features.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
		[HttpPost]
		public ActionResult AddFeature(Feature feature)
		{
           _context.Features.Add(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult RemoveFeature(int id)
        {

            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");

		}
	}
}