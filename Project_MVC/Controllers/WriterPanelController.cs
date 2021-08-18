using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_MVC.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator wv = new WriterValidator();
        int writerid;
        [HttpGet]
        public ActionResult WriterProfile()
        {
            string p = (string)Session["WriterMail"];
            writerid = wm.GetByMail(p).WriterId;
            var value = wm.GetById(writerid);
            return View(value);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["Writermail"];
            writerid = wm.GetByMail(p).WriterId;
            var value = hm.GetListByWriter(writerid);
            return View(value);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                 ).ToList();
            ViewBag.vlc = valueCategory;
            
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string a = (string)Session["WriterMail"];
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            writerid = wm.GetByMail(a).WriterId;
            heading.WriterId = writerid;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                 ).ToList();
            ViewBag.vlc1 = valueCategory;
            var headingvalues = hm.GetById(id);
            return View(headingvalues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
           // headingValue.HeadingStatus = false;
            hm.HeadingDeleteStatus(headingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading()
        {
            var headings = hm.GetList();
            return View(headings);
        }
    }
}