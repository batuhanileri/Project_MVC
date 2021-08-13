using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword==admin.AdminPassword );
            if(adminUserInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index","AdminCategory");

            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //[HttpGet]
        //public ActionResult SignUp()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult SignUp(SignUp signUp)
        //{
           
        //        wm.WriterAdd(writer);
        //        return RedirectToAction("Index");

           
        //        foreach (var item in results.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}
       

    }
}