using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        
        public ActionResult Inbox()
        {
            

            string p = (string)Session["EMail"];            
            var value = mm.GetListInbox(p);
            var count = mm.GetListStatusFalse().Count();
            ViewBag.d1 = count;
            return View(value);
            //var value = mm.GetList();
            //var count = mm.GetListStatusFalse().Count();
            //ViewBag.d1 = count;
            //return View(value);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["EMail"];
            var value = mm.GetListSendInbox(p);
            return View(value);
            
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            //message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //mm.MessageAdd(message);
            //return View("Sendbox");
            string p = (string)Session["EMail"];
            message.SenderMail = p;
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.MessageAdd(message);
            return View();
        }
        public ActionResult DeleteMessage(int id)
        {
            var messageValue = mm.GetById(id);
            messageValue.MessagesStatus = false;
            mm.MessageDelete(messageValue);            
            return RedirectToAction("Inbox");
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
        public ActionResult Trash()
        {
            

            var messages = mm.GetFalseMessage();
           
            return View(messages);

        }
    }
}