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
        private Models.ReportingCapstoneDBContext db = new Models.ReportingCapstoneDBContext();

        // GET: DownTimeEvents
        public ActionResult Index()
        {
            ViewBag.DB = db;
            

            return View(db.DownTimeEvents.ToList());
        }

        // GET: DownTimeEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeEvent downTimeEvent = db.DownTimeEvents.Find(id);
            if (downTimeEvent == null)
            {
                return HttpNotFound();
            }
            return View(downTimeEvent);
        }
        
        // GET: DownTimeEvents/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentSelection = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.EventSelection = new SelectList(db.DownTimeTypes, "Id", "Description");

            return View();
        }

        // POST: DownTimeEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DownTimeTypeId,DepartmentId,Date,Duration")] DownTimeEvent downTimeEvent)
        {
            if (ModelState.IsValid)
            {
                Department thisDepartment = (Department)db.Departments.First(o => o.Id == downTimeEvent.DepartmentId);
                DownTimeType errorType = (DownTimeType)db.DownTimeTypes.First(o => o.Id == downTimeEvent.DownTimeTypeId);

                downTimeEvent.departmentName = thisDepartment.DepartmentName;
                downTimeEvent.ErrorTypeName = errorType.Description;

                db.DownTimeEvents.Add(downTimeEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(downTimeEvent);
        }

        // GET: DownTimeEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.DepartmentSelection = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.EventSelection = new SelectList(db.DownTimeTypes, "Id", "Description");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeEvent downTimeEvent = db.DownTimeEvents.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,DownTimeTypeId,DepartmentId,Date,Duration")] DownTimeEvent downTimeEvent)
        {
            Department thisDepartment = (Department)db.Departments.First(o => o.Id == downTimeEvent.DepartmentId);
            DownTimeType errorType = (DownTimeType)db.DownTimeTypes.First(o => o.Id == downTimeEvent.DownTimeTypeId);

            downTimeEvent.departmentName = thisDepartment.DepartmentName;
            downTimeEvent.ErrorTypeName = errorType.Description;

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
            DownTimeEvent downTimeEvent = db.DownTimeEvents.Find(id);
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
            DownTimeEvent downTimeEvent = db.DownTimeEvents.Find(id);
            db.DownTimeEvents.Remove(downTimeEvent);
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
