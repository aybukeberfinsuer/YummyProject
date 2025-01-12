using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ProductController : Controller
    {
        YummyContext _context= new YummyContext();
        public ActionResult Index()
        {
            var values = _context.Products.ToList();
            return View(values);
        }

        public ActionResult Delete(int id) {

            var item = _context.Products.Find(id);
            _context.Products.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
			CategoryDropDown();
			return View();

		}

		[HttpPost]
		public ActionResult Create(Product prd)
		{
			CategoryDropDown();
			if (!ModelState.IsValid)
			{
				return View(prd);
			}
			_context.Products.Add(prd);
			_context.SaveChanges();
			return RedirectToAction("Index");



		}

		private void CategoryDropDown()
		{
			var categoryList = _context.Categories.ToList();
			List<SelectListItem> categories = (from x in categoryList
											   select new SelectListItem
											   {
												   Text = x.CategoryName,
												   Value = x.CategoryId.ToString(),
											   }).ToList();

			ViewBag.categories = categories;
		}


		[HttpGet]
		public ActionResult Update(int id)
		{
			CategoryDropDown();
			var value = _context.Products.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult Update(Product prd)
		{
			CategoryDropDown();
			var value = _context.Products.Find(prd.ProductId);
			value.ImageUrl = prd.ImageUrl;
			value.Productname = prd.Productname;
			value.Ingredients = prd.Ingredients;
			value.Price = prd.Price;
			value.CategoryId = prd.CategoryId;
			
			if (!ModelState.IsValid)
			{
				return View(prd);
			}
			_context.SaveChanges();
			return RedirectToAction("Index");
		}








	}
}