using EntityLayer.Concrete;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Abstract
{
    interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListStatusFalse();
        List<Message> GetListStatusTrue();
        List<Message> GetListSendInbox(string p);
        List<Message> GetList();

        void MessageAdd(Message message,AdminForLoginDto adminForLoginDto);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        List<Message> GetFalseMessage();
        Message GetByMail(String  mail);

    }
}
