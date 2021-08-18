using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace Project_MVC.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult MyContent(string p)
        {
            int id;
            p = (string)Session["Writermail"];
            var writerinfo = wm.GetByMail(p);
            id = writerinfo.WriterId;
            var value = cm.GetListByWriterId(id);
            return View(value);

        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        } 
        [HttpPost]
        public ActionResult AddContent(Content p)
        {

            var mail = (string)Session["Writermail"];
            var writerinfo = wm.GetByMail(mail);

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId=writerinfo.WriterId;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return View("MyContent");
        }
    }
}