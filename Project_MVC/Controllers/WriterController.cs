using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.EDto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context context = new Context();

        public ActionResult Index()
        {

            var writervalues = wm.GetList();

            return View(writervalues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(WriterForRegisterDto writerForRegisterDto,string mail)
        {
            Session["EMail"] = writerForRegisterDto.Mail.ToString();
            

            if (context.Writers.Where(x => x.WriterMail == mail).Any())
            {
                ViewBag.Mesaj = "Bu mail adresiyle daha önce kayıt yapıldı.";
                return View("AddWriter");
            }
            else
            {

                wm.WriterAdd(writerForRegisterDto, writerForRegisterDto.Password);

                return RedirectToAction("Index");
            }
            //WriterValidator writerValidator = new WriterValidator();
            //ValidationResult results = writerValidator.Validate(writer);
            //if (results.IsValid)
            //{
            //    wm.WriterAdd(writer);
            //    return RedirectToAction("Index");

            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writer = wm.GetById(id);
            return View(writer);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer w)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(w);
            if (results.IsValid)
            {
                wm.WriterUpdate(w);
                return RedirectToAction("Index");

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
        public ActionResult DeleteWriter(int id)
        {
            var yazar = wm.GetById(id);
            wm.WriterDelete(yazar);
            return RedirectToAction("Index");
        }
    }
}