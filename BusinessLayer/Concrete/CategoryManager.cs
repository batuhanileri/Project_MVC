﻿using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();
   
        public List<Category> GetAll()
        {
            return repo.GetAll();
        }
        public void CategoryAddBL(Category p)
        {
            if(p.CategoryName=="" || p.CategoryName.Length<=2||
               p.CategoryDescription=="")
            {
                //hata mesajı
            }
            else
            {
                repo.Add(p);
            }
        }
    }
}
