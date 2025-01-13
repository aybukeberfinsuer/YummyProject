using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using Microsoft.Ajax.Utilities;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

		// GET: Default
		 YummyContext context= new YummyContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultProduct()
        {
            var values =context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEvent()
        {
            var values= context.Events.ToList();
            return  PartialView(values);

        }

        public PartialViewResult DefaultService()
        {
            var values = context.Services.ToList();
            return PartialView(values);

        }


		public PartialViewResult DefaultChefs()
		{
			var values = context.Chefs.Include(c => c.ChefSocial).ToList();
			return PartialView(values);
		}


        public ActionResult Booking()
        {
            return View();
        }


	}
}