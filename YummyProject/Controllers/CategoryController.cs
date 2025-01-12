using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;
using System.Data.Entity;


namespace YummyProject.Controllers
{
	public class CategoryController : Controller
	{
		YummyContext _context = new YummyContext();
		public ActionResult Index()
		{
			var values = _context.Categories.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Category ctg)
		{
			if (!ModelState.IsValid)
			{
				return View(ctg);
			}
			_context.Categories.Add(ctg);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var category = _context.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryId == id);

			if (category == null)
			{
				TempData["ErrorMessage"] = "Kategori bulunamadı.";
				return RedirectToAction("Index"); 
			}

			if (category.Products != null && category.Products.Any())
			{
				TempData["ErrorMessage"] = "Bu kategoriye bağlı ürünler mevcut. Önce bu ürünleri silmelisiniz.";
				return RedirectToAction("Index"); // Geri Index'e yönlendirilir
			}

			
			_context.Categories.Remove(category);
			_context.SaveChanges();

			TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Update(int id)
		{
			var value = _context.Categories.Find(id);
			return View(value);

		}

		[HttpPost]
		public ActionResult Update(Category model)
		{
			
			var value = _context.Categories.Find(model.CategoryId);
			value.CategoryName = model.CategoryName;
			
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			_context.SaveChanges();
			return RedirectToAction("Index");
		}







	}
}