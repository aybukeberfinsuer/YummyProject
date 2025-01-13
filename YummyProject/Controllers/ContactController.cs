using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        YummyContext _context= new YummyContext();

        public ActionResult Index()
        {
            var values = _context.ContactInfos.ToList();
			return View(values);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = _context.ContactInfos.Find(id);
            return View(value);
        }
		[HttpPost]
		public ActionResult Update(ContactInfo contact)
		{
			var value = _context.ContactInfos.Find(contact.ContactInfoId);
            value.Address = contact.Address;
            value.Email = contact.Email;
            value.MapUrl = contact.MapUrl;
            value.openHours = contact.openHours;

            _context.SaveChanges();


            return RedirectToAction("Index");
		}
	}
}