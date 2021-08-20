using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC.Controllers
{
    public class AuthorizationsController : Controller
    {
       
       
            // GET: Authorization
            AdminManager adm = new AdminManager(new EfAdminDal());
            AdminRoleManager admRole = new AdminRoleManager(new EfAdminRoleDal());
            Context context = new Context();

        public ActionResult Index()
            {
                var adminvalues = adm.GetList();
                return View(adminvalues);
            }
            [HttpGet]
            public ActionResult NewAdmin()
            {
                
                List<SelectListItem> valueRole = (from x in admRole.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.RoleName,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
                ViewBag.dgr1 = valueRole;
                return View();
            }
            [HttpPost]
            public ActionResult NewAdmin(string mail,AdminForRegisterDto c)
            {
            
                Session["EMail"] = c.Mail.ToString();

           
                if (context.Admines.Where(x => x.Mail == mail).Any())
                {
                    ViewBag.Mesaj = "Bu mail adresiyle daha önce kayıt yapıldı.";
                    return View("NewAdmin");
                }
                else
                {
                                  
                    adm.AdminAdd(c, c.Password);                  
                                   
                return View(c);
                }
            }
        //private void SendActivationEmail(Manager manager, AdminForRegisterDto c)
        //{
        //    string p = (string)Session["EMail"];
        //    manager.Mail = p;
           

        //    using (MailMessage mm = new MailMessage("bertictest@gmail.com", c.Mail))
        //    {
        //        mm.Subject = "Hesap Aktivasyonu";
        //        string body = "Merhaba " + c.UserName + ",";
        //        body += "<br /><br />Hesabınızı etkinleştirmek için lütfen aşağıdaki bağlantıyı tıklayın";
        //        body += "<br /><a href = '" + string.Format("{0}://{1}/Authorizations/Confirmation/{2}", Request.Url.Scheme, Request.Url.Authority, manager.Admin_Confirmation_Code1 +manager.Admin_Confirmation_Code2 )+ "'>Hesabınızı etkinleştirmek için burayı tıklayın.</a>";
        //        body += "<br /><br />Teşekkürler";
        //        mm.Body = body;
        //        mm.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.EnableSsl = true;
        //        NetworkCredential NetworkCred = new NetworkCredential("bertictest@gmail.com", "147896325a.s");
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = NetworkCred;
        //        smtp.Port = 587;
        //        smtp.Send(mm);
        //    }
        //}

       
        [HttpGet]
            public ActionResult ChangeRole(int id)
            {
                List<SelectListItem> valueRole = (from x in admRole.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.RoleName,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
                ViewBag.dgr1 = valueRole;
                var value = adm.GetById(id);
                return View(value);
            }
            [HttpPost]
            public ActionResult ChangeRole(Manager manager)
            {

                adm.ChangeRole(manager.Id, manager.Role);
                return RedirectToAction("Index");
            }
            public ActionResult DeleteAdmin(int id)
            {
                var value = adm.GetById(id);
                value.Status = false;
                adm.AdminUpdate(value);              
                return RedirectToAction("Index");
        }
    }

}