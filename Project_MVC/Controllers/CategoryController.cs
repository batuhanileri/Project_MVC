﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var category_values = cm.GetList();
            return View(category_values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
            [HttpPost]
        public ActionResult AddCategory(Category p)
        {
          //  cm.CategoryAddBL(p);
            return RedirectToAction("GetCategoryList");
        }
    } 
}