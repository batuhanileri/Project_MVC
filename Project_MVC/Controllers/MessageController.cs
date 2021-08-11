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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate =DateTime.Parse( DateTime.Now.ToShortDateString());
              


                mm.MessageAdd(message);
                return RedirectToAction("Sendbox");

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
        public ActionResult DeleteMessage(int id)
        {
            var messageValue = mm.GetById(id);
            messageValue.MessagesStatus = false;
            mm.MessageDelete(messageValue);            
            return RedirectToAction("Inbox");
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var Values = mm.GetById(id);

            return View(Values);
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