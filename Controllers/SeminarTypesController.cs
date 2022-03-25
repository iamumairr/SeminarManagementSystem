using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SeminarManagementSystem.Data;
using SeminarManagementSystem.Models;

namespace SeminarManagementSystem.Controllers
{
    public class SeminarTypesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: SeminarTypes
        public ActionResult Index()
        {
            return View(db.SeminarTypes.ToList());
        }

        // GET: SeminarTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeminarTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeminarType seminarType)
        {
            if (ModelState.IsValid)
            {
                db.SeminarTypes.Add(seminarType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seminarType);
        }

        // GET: SeminarTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeminarType seminarType = db.SeminarTypes.Find(id);
            if (seminarType == null)
            {
                return HttpNotFound();
            }
            return View(seminarType);
        }

        // POST: SeminarTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeminarType seminarType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seminarType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seminarType);
        }

        // GET: SeminarTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeminarType seminarType = db.SeminarTypes.Find(id);
            if (seminarType == null)
            {
                return HttpNotFound();
            }
            return View(seminarType);
        }

        // POST: SeminarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeminarType seminarType = db.SeminarTypes.Find(id);
            db.SeminarTypes.Remove(seminarType);
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
