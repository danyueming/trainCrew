using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace trainCrew.ExceptionLog
{
    public class BaseExceptionController : Controller
    {

        protected override void OnException(ExceptionContext filterContext)
        {

            LogManager logManager = new LogManager(Server.MapPath("~/Exception.txt"));

            logManager.SaveLog(filterContext.Exception.Message, DateTime.Now);

            base.OnException(filterContext);

        }

    }
}