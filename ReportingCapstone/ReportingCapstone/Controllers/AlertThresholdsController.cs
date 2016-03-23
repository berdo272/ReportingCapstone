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
    public class AlertThresholdsController : Controller
    {
        private Models.ReportingCapstoneDBContext db = new Models.ReportingCapstoneDBContext();

        // GET: AlertThresholds
        public ActionResult Index()
        {
            return View(db.AlertThresholds.ToList());
        }

        // GET: AlertThresholds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlertThreshold alertThreshold = db.AlertThresholds.Find(id);
            if (alertThreshold == null)
            {
                return HttpNotFound();
            }
            return View(alertThreshold);
        }

        // GET: AlertThresholds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlertThresholds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PercentDowntimeThreshold,AditionalAlertNotes")] AlertThreshold alertThreshold)
        {
            if (ModelState.IsValid)
            {
                db.AlertThresholds.Add(alertThreshold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alertThreshold);
        }

        // GET: AlertThresholds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlertThreshold alertThreshold = db.AlertThresholds.Find(id);
            if (alertThreshold == null)
            {
                return HttpNotFound();
            }
            return View(alertThreshold);
        }

        // POST: AlertThresholds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PercentDowntimeThreshold,AditionalAlertNotes")] AlertThreshold alertThreshold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alertThreshold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alertThreshold);
        }

        // GET: AlertThresholds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlertThreshold alertThreshold = db.AlertThresholds.Find(id);
            if (alertThreshold == null)
            {
                return HttpNotFound();
            }
            return View(alertThreshold);
        }

        // POST: AlertThresholds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlertThreshold alertThreshold = db.AlertThresholds.Find(id);
            db.AlertThresholds.Remove(alertThreshold);
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
