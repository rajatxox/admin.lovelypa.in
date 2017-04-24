using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admin_lovelypa_in;

namespace admin_lovelypa_in.Controllers
{
    [Authorize]
    public class MPA_CURRENT_SEMESTERController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_CURRENT_SEMESTER
        public ActionResult Index()
        {
            var mPA_CURRENT_SEMESTER = db.MPA_CURRENT_SEMESTER.Include(m => m.MPA_USER_DATA);
            return View(mPA_CURRENT_SEMESTER.ToList());
        }

        // GET: MPA_CURRENT_SEMESTER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_CURRENT_SEMESTER mPA_CURRENT_SEMESTER = db.MPA_CURRENT_SEMESTER.Find(id);
            if (mPA_CURRENT_SEMESTER == null)
            {
                return HttpNotFound();
            }
            return View(mPA_CURRENT_SEMESTER);
        }

        // GET: MPA_CURRENT_SEMESTER/Create
        public ActionResult Create()
        {
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name");
            return View();
        }

        // POST: MPA_CURRENT_SEMESTER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,reg_id,subject_code,subject_name,last_updated,total_class,duty_leave,present")] MPA_CURRENT_SEMESTER mPA_CURRENT_SEMESTER)
        {
            if (ModelState.IsValid)
            {
                db.MPA_CURRENT_SEMESTER.Add(mPA_CURRENT_SEMESTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_CURRENT_SEMESTER.reg_id);
            return View(mPA_CURRENT_SEMESTER);
        }

        // GET: MPA_CURRENT_SEMESTER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_CURRENT_SEMESTER mPA_CURRENT_SEMESTER = db.MPA_CURRENT_SEMESTER.Find(id);
            if (mPA_CURRENT_SEMESTER == null)
            {
                return HttpNotFound();
            }
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_CURRENT_SEMESTER.reg_id);
            return View(mPA_CURRENT_SEMESTER);
        }

        // POST: MPA_CURRENT_SEMESTER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,reg_id,subject_code,subject_name,last_updated,total_class,duty_leave,present")] MPA_CURRENT_SEMESTER mPA_CURRENT_SEMESTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_CURRENT_SEMESTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_CURRENT_SEMESTER.reg_id);
            return View(mPA_CURRENT_SEMESTER);
        }

        // GET: MPA_CURRENT_SEMESTER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_CURRENT_SEMESTER mPA_CURRENT_SEMESTER = db.MPA_CURRENT_SEMESTER.Find(id);
            if (mPA_CURRENT_SEMESTER == null)
            {
                return HttpNotFound();
            }
            return View(mPA_CURRENT_SEMESTER);
        }

        // POST: MPA_CURRENT_SEMESTER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_CURRENT_SEMESTER mPA_CURRENT_SEMESTER = db.MPA_CURRENT_SEMESTER.Find(id);
            db.MPA_CURRENT_SEMESTER.Remove(mPA_CURRENT_SEMESTER);
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
