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
    public class EmailAddressesController : Controller
    {
        private ReportingCapstoneDBContext db = new ReportingCapstoneDBContext();

        // GET: EmailAddresses
        public ActionResult Index()
        {
            return View(db.EmailList.ToList());
        }

        // GET: EmailAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailAddress emailAddress = db.EmailList.Find(id);
            if (emailAddress == null)
            {
                return HttpNotFound();
            }
            return View(emailAddress);
        }


        // GET: EmailAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email")] EmailAddress emailAddress)
        {
            if (ModelState.IsValid)
            {
                db.EmailList.Add(emailAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emailAddress);
        }

        // GET: EmailAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailAddress emailAddress = db.EmailList.Find(id);
            if (emailAddress == null)
            {
                return HttpNotFound();
            }
            return View(emailAddress);
        }

        // POST: EmailAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email")] EmailAddress emailAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailAddress);
        }

        // GET: EmailAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailAddress emailAddress = db.EmailList.Find(id);
            if (emailAddress == null)
            {
                return HttpNotFound();
            }
            return View(emailAddress);
        }

        // POST: EmailAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailAddress emailAddress = db.EmailList.Find(id);
            db.EmailList.Remove(emailAddress);
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
