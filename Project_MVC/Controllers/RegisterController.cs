using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Register
        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterForRegisterDto writer)
        {
            wm.Register(writer, writer.Password);
            return View();
        }
    }
}