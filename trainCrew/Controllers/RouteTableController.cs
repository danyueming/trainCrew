using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trainCrew.Models.Train;
using trainCrew.HandleFunction;

namespace trainCrew.Controllers
{
    public class RouteTableController : Controller
    {
     

      
        //
        // GET: /RouteTable/
        public ActionResult Index()
        {
            ReadFile rd = new ReadFile();
            rd.Read();
            int size = Common.routelines.Count();//车次链的数目

            Genotype.bodyofgenetic();

            var result = Common.services;

            return View();
        }
	}
}