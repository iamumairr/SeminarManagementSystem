using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SeminarManagementSystem.Data;
using SeminarManagementSystem.Models;

namespace SeminarManagementSystem.Controllers
{
    public class SeminarOrganizersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: SeminarOrganizers
        public ActionResult Index()
        {
            var seminarOrganizers = db.SeminarOrganizers.Include(s => s.Organizer).Include(s => s.Seminar);
            return View(seminarOrganizers.ToList());
        }

        // GET: SeminarOrganizers/Create
        public ActionResult Create()
        {
            ViewBag.OrganizerId = new SelectList(db.Organizers, "Id", "Name");
            ViewBag.SeminarId = new SelectList(db.Seminars, "Id", "Name");
            return View();
        }

        // POST: SeminarOrganizers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SeminarId,OrganizerId")] SeminarOrganizer seminarOrganizer)
        {
            if (ModelState.IsValid)
            {
                db.SeminarOrganizers.Add(seminarOrganizer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizerId = new SelectList(db.Organizers, "Id", "Name", seminarOrganizer.OrganizerId);
            ViewBag.SeminarId = new SelectList(db.Seminars, "Id", "Name", seminarOrganizer.SeminarId);
            return View(seminarOrganizer);
        }

        // GET: SeminarOrganizers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeminarOrganizer seminarOrganizer = db.SeminarOrganizers.Find(id);
            if (seminarOrganizer == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizerId = new SelectList(db.Organizers, "Id", "Name", seminarOrganizer.OrganizerId);
            ViewBag.SeminarId = new SelectList(db.Seminars, "Id", "Name", seminarOrganizer.SeminarId);
            return View(seminarOrganizer);
        }

        // POST: SeminarOrganizers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SeminarId,OrganizerId")] SeminarOrganizer seminarOrganizer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seminarOrganizer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizerId = new SelectList(db.Organizers, "Id", "Name", seminarOrganizer.OrganizerId);
            ViewBag.SeminarId = new SelectList(db.Seminars, "Id", "Name", seminarOrganizer.SeminarId);
            return View(seminarOrganizer);
        }

        // GET: SeminarOrganizers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeminarOrganizer seminarOrganizer = db.SeminarOrganizers.Find(id);
            if (seminarOrganizer == null)
            {
                return HttpNotFound();
            }
            return View(seminarOrganizer);
        }

        // POST: SeminarOrganizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeminarOrganizer seminarOrganizer = db.SeminarOrganizers.Find(id);
            db.SeminarOrganizers.Remove(seminarOrganizer);
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
