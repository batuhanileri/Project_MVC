using EntityLayer.Concrete;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListStatusFalse();
        List<Message> GetListStatusTrue();
        List<Message> GetListSendInbox(string p);
        List<Message> GetList();

        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        List<Message> GetFalseMessage();
    }
}
