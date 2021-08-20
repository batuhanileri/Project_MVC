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
        public ActionResult Inbox()
        {
            string p = (string)Session["Writermail"];
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
    }
}