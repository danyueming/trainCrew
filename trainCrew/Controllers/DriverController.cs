using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trainCrew.Models;
using trainCrew.DAL;

namespace trainCrew.Controllers
{
    public class DriverController : Controller
    {
        private TrainContext db = new TrainContext();

        // GET: /Driver/
        //public ActionResult Index()
        //{
        //    var drivers = db.Drivers.Include(d => d.DriverGroup);
        //    return View(drivers.ToList());
        //}

        // GET: /Driver/Details/5

        public ActionResult Index(string drivertype, string searching)
        {
            var driverList = new List<string>();
            var driverQry = from d in db.Drivers
                            orderby d.DriveType
                            select d.DriveType;//查询司机的类型
            driverList.AddRange(driverQry.Distinct());//delete the Duplicated,删除重复的
            ViewBag.drivertype = new SelectList(driverList);//传递给前端

            var driverset = from m in db.Drivers.Include(d => d.DriverGroup.DriverTeam)//查询司机
                            select m;
            if (!String.IsNullOrEmpty(searching))
            {
                driverset = driverset.Where(s => s.DriverName.Contains(searching));//查询司机名

            }
            if (!String.IsNullOrEmpty(drivertype))
            {

                driverset = driverset.Where(s => s.DriveType == drivertype);
            }


            return View(driverset);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: /Driver/Create
        public ActionResult Create()
        {
            ViewBag.DriverGroupID = new SelectList(db.DriverGroups, "DriverGroupID", "DriverGroupName");
            ViewBag.DriverTeamID = new SelectList(db.DriverTeams, "DriverTeamID", "TeamName");
            return View();
        }

        // POST: /Driver/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverTeamID,DriverGroupID,DriverName,Sex,Birthday,DriveType")] Driver driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Drivers.Add(driver);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException /* dex */) 
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.DriverGroupID = new SelectList(db.DriverGroups, "DriverGroupID", "DriverGroupName", driver.DriverGroupID);
            return View(driver);
        }

        // GET: /Driver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverGroupID = new SelectList(db.DriverGroups, "DriverGroupID", "DriverGroupName", driver.DriverGroupID);
            ViewBag.DriverTeamID = new SelectList(db.DriverTeams, "DriverTeamID", "TeamName", driver.DriverGroup.DriverTeamID);
            return View(driver);
        }

        // POST: /Driver/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverID,DriverTeamID,DriverGroupID,DriverName,Sex,Birthday,DriveType")] Driver driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(driver).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }
            
            ViewBag.DriverGroupID = new SelectList(db.DriverGroups, "DriverGroupID", "DriverGroupName", driver.DriverGroupID);
            ViewBag.DriverTeamID = new SelectList(db.DriverTeams, "DriverTeamID", "TeamName", driver.DriverGroup.DriverTeamID);
            return View(driver);
        }

        // GET: /Driver/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: /Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try 
            {
                Driver driver = db.Drivers.Find(id);
                db.Drivers.Remove(driver);
                db.SaveChanges();                          
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");

           
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
