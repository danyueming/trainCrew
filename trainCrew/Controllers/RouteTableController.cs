﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trainCrew.Models.Train;
using trainCrew.HandleFunction;
using System.Threading;

namespace trainCrew.Controllers
{
    public class RouteTableController : Controller
    {
     

      
        //
        // GET: /RouteTable/
          [AllowAnonymous]
        public ActionResult Index()
        {
            ReadFile rd = new ReadFile();
            rd.Read();
            int size = Common.routelines.Count();//车次链的数目

            Genotype.bodyofgenetic();

            var result = Common.services;

            Thread CreateExcelthread = new Thread(new ThreadStart(CreatExcel.Creat));
            CreateExcelthread.Start();

            


            return View();
        }
	}
}