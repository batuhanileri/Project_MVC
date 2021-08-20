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
            

            if ((adm.Login(manager,admin)))
            {
                
                if (manager.Status==true)
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
                    ViewBag.Mesaj = "Böyle Bir kullanıcı yoktur.";
                }


            
            return View();

        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(WriterForLoginDto writer)
        {
            if ((wm.Login(writer)))
            {
                FormsAuthentication.SetAuthCookie(writer.Email, false);
                Session["Writermail"] = writer.Email.ToString();
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return View();
            }
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
