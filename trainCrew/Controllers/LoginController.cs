using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using trainCrew.Models;
using System.Data.Entity;
using trainCrew.DAL;

namespace trainCrew.Controllers
{
    public class LoginController : Controller
    {
        private TrainContext UserContext = new  TrainContext();
        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [AllowAnonymous]
        public ActionResult Contact(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Message = "Your contact page.";
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(SystemUser model, string ReturnUser)
        {
            if (ModelState.IsValid)
            {
                var users = from item in UserContext.SystemUsers
                            where item.Name == model.Name && item.Password == model.Password
                            select item;
                if (users.Any())
                {
                    return RedirectToAction("List", "Menu",model);
                    //  return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("About", "Home");
            }
        }

    }
}