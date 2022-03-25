using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SeminarManagementSystem.Data;
using SeminarManagementSystem.Models;

namespace SeminarManagementSystem.Controllers
{
    public class RegistrationsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var registrations = db.Registrations.Include(r => r.Attendee).Include(r => r.Seminar);
            return View(registrations.ToList());
        }


        public ActionResult Create()
        {
            ViewBag.AttendeeId = new SelectList(db.Attendees, "Id", "Name");
            ViewBag.SeminarId = new SelectList(db.Seminars, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                registration.RegistrationDate = DateTime.Now;
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttendeeId = new SelectList(db.Attendees, "Id", "Name", registration.AttendeeId);
            ViewBag.SeminarId = new SelectList(db.Seminars, "Id", "Name", registration.SeminarId);
            return View(registration);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttendeeId = new SelectList(db.Attendees, "Id", "Name", registration.AttendeeId);
            ViewBag.SeminarId = new SelectList(db.Seminars, "Id", "Name", registration.SeminarId);
            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registration registration)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Registrations.Find(registration.Id);
                if (obj != null)
                {
                    registration.RegistrationDate = obj.RegistrationDate;
                    db.Entry(obj).State = EntityState.Detached;
                }
               
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttendeeId = new SelectList(db.Attendees, "Id", "Name", registration.AttendeeId);
            ViewBag.SeminarId = new SelectList(db.Seminars, "Id", "Name", registration.SeminarId);
            return View(registration);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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
