using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
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

        public List<Message> GetListInbox()
        {
            return _messageDal.GetAll(x=>x.ReceiverMail=="luka@gmail.com" && x.MessagesStatus==true);
        }
        public List<Message> GetListSendbox()
        {
            return _messageDal.GetAll(x => x.SenderMail == "luka@gmail.com");
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
           
            return _messageDal.GetAll(x=>x.MessagesStatus==true);
        }

        public List<Message> GetFalseMessage()
        {
            return _messageDal.GetAll(x=>x.MessagesStatus==false);


        }
    }
}
