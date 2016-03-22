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
    public class DownTimeTypesController : Controller
    {
        private ReportingCapstoneDBContext db = new ReportingCapstoneDBContext();

        // GET: DownTimeTypes
        public ActionResult Index()
        {
            return View(db.ErrorCodes.ToList());
        }

        // GET: DownTimeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeType downTimeTypes = db.ErrorCodes.Find(id);
            if (downTimeTypes == null)
            {
                return HttpNotFound();
            }
            return View(downTimeTypes);
        }

        // GET: DownTimeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DownTimeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] DownTimeType downTimeTypes)
        {
            if (ModelState.IsValid)
            {
                db.ErrorCodes.Add(downTimeTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(downTimeTypes);
        }

        // GET: DownTimeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeType downTimeTypes = db.ErrorCodes.Find(id);
            if (downTimeTypes == null)
            {
                return HttpNotFound();
            }
            return View(downTimeTypes);
        }

        // POST: DownTimeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] DownTimeType downTimeTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downTimeTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(downTimeTypes);
        }

        // GET: DownTimeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeType downTimeTypes = db.ErrorCodes.Find(id);
            if (downTimeTypes == null)
            {
                return HttpNotFound();
            }
            return View(downTimeTypes);
        }

        // POST: DownTimeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DownTimeType downTimeTypes = db.ErrorCodes.Find(id);
            db.ErrorCodes.Remove(downTimeTypes);
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
