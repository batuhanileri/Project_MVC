﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        void ContentAdd(Content content);
        Content GetById(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        List<Content> GetListByHeadingId(int id);
        List<Content> GetListByWriterId(int id);
    }
}
