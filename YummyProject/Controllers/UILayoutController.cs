using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class UILayoutController : Controller
    {
        YummyContext _context = new YummyContext();
        // GET: UILayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SocialMedias()
        {
            var values = _context.SocialMedia.ToList();
            return PartialView(values);
        }
    }
}