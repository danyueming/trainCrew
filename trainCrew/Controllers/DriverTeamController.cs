using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using trainCrew.Models;
using trainCrew.DAL;
using PagedList;

namespace trainCrew.Controllers
{
    public class DriverTeamController : Controller
    {
        private TrainContext db = new TrainContext();

        // GET: /DriverTeam/
        public ActionResult Index(string searchString, int? page)
        {
          

         
            var teams = from t in db.DriverTeams
                        select t;
                        
            if (!String.IsNullOrEmpty(searchString))
            {
                teams = teams.Where(s => s.TeamName.Contains(searchString));

            }
           
                
            teams = teams.OrderBy(s => s.DriverTeamID);
          

            int pageSize = 2;//设置每页的大小
            int pageNumber = (page ?? 1);

            return View(teams.ToPagedList(pageNumber, pageSize));
        }

        // GET: /DriverTeam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverTeam driverteam = db.DriverTeams.Find(id);
            if (driverteam == null)
            {
                return HttpNotFound();
            }
            return View(driverteam);
        }

        // GET: /DriverTeam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DriverTeam/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TeamName,GroupNumber,remark")] DriverTeam driverteam)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    db.DriverTeams.Add(driverteam);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException /*dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Tryagain, and if the problem persists see your system administrator.");

            }
         
            return View(driverteam);
        }

        // GET: /DriverTeam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverTeam driverteam = db.DriverTeams.Find(id);
            if (driverteam == null)
            {
                return HttpNotFound();
            }
            return View(driverteam);
        }

        // POST: /DriverTeam/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DriverTeamID,TeamName,GroupNumber,remark")] DriverTeam driverteam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(driverteam).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
           
            return View(driverteam);
        }

        // GET: /DriverTeam/Delete/5
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
            DriverTeam driverteam = db.DriverTeams.Find(id);

            if (driverteam == null)
            {
                return HttpNotFound();
            }
            return View(driverteam);
        }

        // POST: /DriverTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)//改变方法名，使DeleteConfirmed 变成 Delete 
        {
            try 
            {
                DriverTeam driverteam = db.DriverTeams.Find(id);
                db.DriverTeams.Remove(driverteam);
                /*
                  DriverTeam driverteamToDelete = new DriverTeam(){DriverTeamID = id} ;//一种性能更高的写法
                  db.Entry(driverteamToDelete).State = EntityState.Deleted;
                */
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
