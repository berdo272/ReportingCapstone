using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReportingCapstone.Models;

namespace ReportingCapstone.Controllers
{
    public class DownTimeEventsController : Controller
    {
        private ReportingCapstoneDBContext db = new ReportingCapstoneDBContext();

        // GET: DownTimeEvents
        public ActionResult Index()
        {
            return View(db.DowntimeLog.ToList());
        }

        // GET: DownTimeEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeEvent downTimeEvent = db.DowntimeLog.Find(id);
            if (downTimeEvent == null)
            {
                return HttpNotFound();
            }
            return View(downTimeEvent);
        }

        // GET: DownTimeEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DownTimeEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProblemCode,DepartmentCode,Date,Duration")] DownTimeEvent downTimeEvent)
        {
            if (ModelState.IsValid)
            {
                db.DowntimeLog.Add(downTimeEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(downTimeEvent);
        }

        // GET: DownTimeEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeEvent downTimeEvent = db.DowntimeLog.Find(id);
            if (downTimeEvent == null)
            {
                return HttpNotFound();
            }
            return View(downTimeEvent);
        }

        // POST: DownTimeEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProblemCode,DepartmentCode,Date,Duration")] DownTimeEvent downTimeEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downTimeEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(downTimeEvent);
        }

        // GET: DownTimeEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeEvent downTimeEvent = db.DowntimeLog.Find(id);
            if (downTimeEvent == null)
            {
                return HttpNotFound();
            }
            return View(downTimeEvent);
        }

        // POST: DownTimeEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DownTimeEvent downTimeEvent = db.DowntimeLog.Find(id);
            db.DowntimeLog.Remove(downTimeEvent);
            db.SaveChanges();
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
