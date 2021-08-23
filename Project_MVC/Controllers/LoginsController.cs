using BusinessLayer.Concrete;
using BusinessLayer.Hashing;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginsController : Controller
    {
        // GET: Logins

        AdminManager adm = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context context = new Context();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Manager manager, AdminForLoginDto admin)
        {
            var userToCheck = adm.GetByMail(admin.Email);

            if ((adm.Login(manager, admin)))
            {

                if (userToCheck.Status == true)
                {
                    FormsAuthentication.SetAuthCookie(admin.Email, false);
                    Session["EMail"] = admin.Email.ToString();
                    Session["Password"] = admin.Password.ToString();

                    return RedirectToAction("Index", "AdminCategory");
                }
                else
                {
                    ViewBag.Mesaj = "Yetkiniz Yoktur.";



                }
            }                 

                else
                {
                    ViewBag.Mesaj = "Kullanıcı Adı Yada Şifre Yanlıştır.";
                }


            
                return View();

        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer w,WriterForLoginDto writerForLoginDto)
        {
            var userToCheck = wm.GetByMail(writerForLoginDto.Email);

            if ((wm.Login(w, writerForLoginDto)))
            {

                if (userToCheck.WriterStatus == true)
                {
                    FormsAuthentication.SetAuthCookie(writerForLoginDto.Email, false);
                    Session["Writermail"] = writerForLoginDto.Email.ToString();
                    Session["Password"] = writerForLoginDto.Password.ToString();

                    return RedirectToAction("MyContent", "WriterPanelContent");
                }
                else
                {
                    ViewBag.Mesaj = "Hesabınız Askıya Alınmış";

                }
            }

            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı Yada Şifre Yanlıştır.";
            }



            return View();


            //if ((wm.Login(writer)))
            //{
            //    FormsAuthentication.SetAuthCookie(writer.Email, false);
            //    Session["Writermail"] = writer.Email.ToString();
            //    return RedirectToAction("MyContent", "WriterPanelContent");
            //}
            //else
            //{
            //    return View();
            //}
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult LogWriterOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin");
        }
    }
}
