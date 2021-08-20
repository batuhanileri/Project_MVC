using Project_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_MVC.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }
        public List<Categories> BlogList()
        {
            List<Categories> ct = new List<Categories>();
            ct.Add(new Categories()
            {
                CategoryName = "YAZILIM",
                CategoryCount = 8
            });
            return ct;
        }
    }
}