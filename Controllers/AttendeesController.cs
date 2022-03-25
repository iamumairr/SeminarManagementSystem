using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SeminarManagementSystem.Data;
using SeminarManagementSystem.Models;

namespace SeminarManagementSystem.Controllers
{
    //controller for handling Attendee Model
    public class AttendeesController : Controller
    {
        //initialization of dbcontext class
        private AppDbContext db = new AppDbContext();

        //index method to display all records
        public ActionResult Index()
        {
            return View(db.Attendees.ToList());
        }
        //create a attendee, get method
        public ActionResult Create()
        {
            return View();
        }
        //post request for create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                db.Attendees.Add(attendee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendee);
        }
        //edit method (HttpGet)
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                return HttpNotFound();
            }
            return View(attendee);
        }
        //post method for edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendee);
        }
        //delete get method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                return HttpNotFound();
            }
            return View(attendee);
        }

        //delete post method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendee attendee = db.Attendees.Find(id);
            db.Attendees.Remove(attendee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //disposing dbcontext class
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
