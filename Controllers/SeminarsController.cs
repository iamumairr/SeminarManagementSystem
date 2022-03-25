using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SeminarManagementSystem.Data;
using SeminarManagementSystem.Models;

namespace SeminarManagementSystem.Controllers
{
    public class SeminarsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View(db.Seminars.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.SeminarTypeId = new SelectList(db.SeminarTypes, "Id", "TypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Seminars.Add(seminar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeminarTypeId = new SelectList(db.SeminarTypes, "Id", "TypeName",seminar.SeminarTypeId);
            return View(seminar);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminars.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeminarTypeId = new SelectList(db.SeminarTypes, "Id", "TypeName", seminar.SeminarTypeId);
            return View(seminar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seminar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeminarTypeId = new SelectList(db.SeminarTypes, "Id", "TypeName", seminar.SeminarTypeId);
            return View(seminar);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminars.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seminar seminar = db.Seminars.Find(id);
            db.Seminars.Remove(seminar);
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
