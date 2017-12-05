using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using trainCrew.Models;



namespace trainCrew.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        [AllowAnonymous]
        public ActionResult List( SystemUser returnUser)
        {
            ViewBag.UserName = returnUser.Name;

            WeatherWeb.WeatherWebService webWeather = new WeatherWeb.WeatherWebService();
           string[] cityWeather = webWeather.getWeatherbyCityName("成都");//获取天气信息

           ViewBag.CityWeather = cityWeather;

            return View();

        }

       


	}
}