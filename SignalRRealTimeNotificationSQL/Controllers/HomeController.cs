﻿using SignalRRealTimeNotificationSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC5_Bootstrap3_3_1_LESS.Controllers
{
    public class HomeController : Controller
    {
        JobInfoRepository objRepo = new JobInfoRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Get()
        {
            return Json(objRepo.GetData(),JsonRequestBehavior.AllowGet);
            //return objRepo.GetData();
        }
    }
}