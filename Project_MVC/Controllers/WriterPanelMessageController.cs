using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.EDto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox(Message message)
        {
            string p = (string)Session["Writermail"];   
            message.ReceiverMail = p;
           // message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var value = mm.GetListInbox(p);
            var count = mm.GetListStatusFalse().Count();
            ViewBag.d1 = count;
            return View(value);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["Writermail"];
            var value = mm.GetListSendInbox(p);
            return View(value);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var value = mm.GetById(id);
            value.MessagesStatus = true;
            mm.MessageUpdate(value);
            return View(value);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var Values = mm.GetById(id);

            return View(Values);
        }
        //[HttpGet]
        //public ActionResult NewMessage()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult NewMessage(Message message)
        //{
        //    string p = (string)Session["Writermail"];
        //    message.SenderMail = p;
        //    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    mm.MessageAdd(message);
        //    return View();
        //}
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message, WriterForLoginDto writerForLoginDto, HttpPostedFileBase myFiles)
        {
            //message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //mm.MessageAdd(message);
            //return View("Sendbox");
            string p = (string)Session["Writermail"];
            string c = (string)Session["Password"];
            message.SenderMail = p;
            writerForLoginDto.Password = c;
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(message.ReceiverMail);//alıcı
            mailMessage.From = new MailAddress(message.SenderMail, "TICKET DESTEK TALEBİ");//gönderen
            mailMessage.Subject = "Konu:  " + message.Subject;
            mailMessage.Body = "<br> Mesaj İçeriği: " + message.MessageContent;
            mailMessage.IsBodyHtml = true;

            if (myFiles != null)
            {
                mailMessage.Attachments.Add(new Attachment(myFiles.InputStream, myFiles.FileName));
            }

            SmtpClient smtp = new SmtpClient();
            NetworkCredential Credentials = new NetworkCredential("bertictest@gmail.com", "147896325a.s");//gönderen mail , şifre
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = Credentials;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            try
            {

                smtp.Send(mailMessage);
                TempData["Message"] = "Mail iletildi";


            }
            catch (Exception ex)
            {

                TempData["Message"] = "Mail Gönderilemedi Hata Nedeni: " + ex.Message;
            }


            mm.MessageAddWriter(message, writerForLoginDto);
            return View();
        }
    }
}