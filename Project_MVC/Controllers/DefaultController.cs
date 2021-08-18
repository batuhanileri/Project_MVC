using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public PartialViewResult Index(int id=0 )
        {
            var contentlist = cm.GetListByHeadingId(id);
            return PartialView(contentlist);
        }
        public ActionResult Headings()
        {
            var heading = hm.GetList();
;            return View(heading);
        }
    }
}