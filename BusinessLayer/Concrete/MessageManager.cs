﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);

        }

        public List<Message> GetListInbox(string p)
        {
            
            return _messageDal.GetAll(x=>x.ReceiverMail==p);
        }
        public List<Message> GetListSendInbox(string p)
        {

            return _messageDal.GetAll(x => x.SenderMail == p );
        }
        public List<Message> GetListStatusFalse()
        {
            return _messageDal.GetAll(x => x.MessagesStatus == false);
        }

        public List<Message> GetListStatusTrue()
        {
            return _messageDal.GetAll(x => x.MessagesStatus == true);
        }


        public void MessageAdd(Message message)
        {
            message.MessagesStatus = true;
            _messageDal.Add(message);

        }

        public void MessageDelete(Message message)
        {
                
                _messageDal.Update(message);
                
           
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);

        }
        public List<Message> GetList()
        {
           
            return _messageDal.GetAll(x=>x.MessagesStatus==true );
        }

        public List<Message> GetFalseMessage()
        {
            return _messageDal.GetAll(x=>x.MessagesStatus==false);


        }
    }
}
