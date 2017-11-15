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
    public class DriveGroupController : Controller
    {
        private TrainContext db = new TrainContext();

        // GET: /DriveGroup/
        public ActionResult Index()
        {
            var drivergroups = db.DriverGroups.Include(d => d.DriverTeam);
            return View(drivergroups.ToList());
        }

        // GET: /DriveGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverGroup drivergroup = db.DriverGroups.Find(id);
            if (drivergroup == null)
            {
                return HttpNotFound();
            }
            return View(drivergroup);
        }

        // GET: /DriveGroup/Create
        public ActionResult Create()
        {
            ViewBag.DriverTeamID = new SelectList(db.DriverTeams, "DriverTeamID", "TeamName");
            return View();
        }

        // POST: /DriveGroup/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverTeamID,DriverGroupName,GroupPeople")] DriverGroup drivergroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DriverGroups.Add(drivergroup);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Tryagain, and if the problem persists see your system administrator.");
            }

            ViewBag.DriverTeamID = new SelectList(db.DriverTeams, "DriverTeamID", "TeamName", drivergroup.DriverTeamID);
            
            return View(drivergroup);
        }

        // GET: /DriveGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverGroup drivergroup = db.DriverGroups.Find(id);
            if (drivergroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverTeamID = new SelectList(db.DriverTeams, "DriverTeamID", "TeamName", drivergroup.DriverTeamID);
            return View(drivergroup);
        }

        // POST: /DriveGroup/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverGroupID,DriverTeamID,DriverGroupName,GroupPeople")] DriverGroup drivergroup)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    db.Entry(drivergroup).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
           
            ViewBag.DriverTeamID = new SelectList(db.DriverTeams, "DriverTeamID", "TeamName", drivergroup.DriverTeamID);
            return View(drivergroup);
        }

        // GET: /DriveGroup/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                 ViewBag.ErrorMessage = "Delete failed. Try again, and if theproblem persists see your system administrator.";
            }
            DriverGroup drivergroup = db.DriverGroups.Find(id);
            if (drivergroup == null)
            {
                return HttpNotFound();
            }
            return View(drivergroup);
        }

        // POST: /DriveGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                DriverGroup drivergroup = db.DriverGroups.Find(id);
                db.DriverGroups.Remove(drivergroup);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
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
