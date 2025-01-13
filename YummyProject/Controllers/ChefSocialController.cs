using System;
using System.Linq;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
	public class ChefSocialController : Controller
	{
		// YummyContext nesnesini başlatıyoruz
		private YummyContext _context = new YummyContext();

		// GET: ChefSocial
		public ActionResult Index(int id)
		{
			var values = _context.ChefSocials.Where(x => x.ChefId == id).ToList();
			ViewBag.ChefId = id; // ChefId'yi ViewBag ile gönderiyoruz
			return View(values);
		}

		[HttpGet]
		public ActionResult Create(int id)
		{
			var chef = _context.Chefs.Find(id);
			if (chef == null)
			{
				return HttpNotFound();
			}

			var chefSocial = new ChefSocial
			{
				ChefId = chef.ChefId
				// Diğer alanları burada başlatabilirsiniz.
			};

			return View(chefSocial);
		}


		// POST: ChefSocial/Create
		[HttpPost]
		public ActionResult Create(ChefSocial chefSocial)
		{
			if (ModelState.IsValid)
			{
				_context.ChefSocials.Add(chefSocial);
				_context.SaveChanges();
				return RedirectToAction("Index", new { id = chefSocial.ChefId });
			}

			ViewBag.ChefId = chefSocial.ChefId;
			return View(chefSocial);
		}



		public ActionResult Delete(int id)
		{
			var chefId = _context.ChefSocials.Find(id).ChefId;
			var deleted_value = _context.ChefSocials.Find(id);
			_context.ChefSocials.Remove(deleted_value);
			_context.SaveChanges();
			return RedirectToAction("Index", new { id = chefId });
		}


		[HttpGet]
		public ActionResult Update(int id)
		{
			var chefSocial = _context.ChefSocials.Find(id);
			if (chefSocial == null)
			{
				return HttpNotFound();
			}
			return View(chefSocial); // model gönderiliyor
		}

		[HttpPost]
		public ActionResult Update(ChefSocial model)
		{
			if (!ModelState.IsValid)
			{
				return View(model); // Model geçersizse, hatalarla birlikte view'ı geri gönder
			}

			var value = _context.ChefSocials.Find(model.ChefSocialId);
			if (value == null)
			{
				return HttpNotFound(); // Eğer ChefSocial bulunmazsa, hataya düşülmeli
			}

			value.Name = model.Name;
			value.Icon = model.Icon;
			value.Url = model.Url;

			_context.SaveChanges();
			return RedirectToAction("Index", new { id = model.ChefId });
		}




	}
}
