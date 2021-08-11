﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetList();

        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        List<Message> GetFalseMessage();
    }
}
