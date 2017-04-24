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
    public class MPA_CGPA_ATTENDANCEController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_CGPA_ATTENDANCE
        public ActionResult Index()
        {
            var mPA_CGPA_ATTENDANCE = db.MPA_CGPA_ATTENDANCE.Include(m => m.MPA_USER_DATA);
            return View(mPA_CGPA_ATTENDANCE.ToList());
        }

        // GET: MPA_CGPA_ATTENDANCE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_CGPA_ATTENDANCE mPA_CGPA_ATTENDANCE = db.MPA_CGPA_ATTENDANCE.Find(id);
            if (mPA_CGPA_ATTENDANCE == null)
            {
                return HttpNotFound();
            }
            return View(mPA_CGPA_ATTENDANCE);
        }

        // GET: MPA_CGPA_ATTENDANCE/Create
        public ActionResult Create()
        {
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name");
            return View();
        }

        // POST: MPA_CGPA_ATTENDANCE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,reg_id,attendance,cgpa")] MPA_CGPA_ATTENDANCE mPA_CGPA_ATTENDANCE)
        {
            if (ModelState.IsValid)
            {
                db.MPA_CGPA_ATTENDANCE.Add(mPA_CGPA_ATTENDANCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_CGPA_ATTENDANCE.reg_id);
            return View(mPA_CGPA_ATTENDANCE);
        }

        // GET: MPA_CGPA_ATTENDANCE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_CGPA_ATTENDANCE mPA_CGPA_ATTENDANCE = db.MPA_CGPA_ATTENDANCE.Find(id);
            if (mPA_CGPA_ATTENDANCE == null)
            {
                return HttpNotFound();
            }
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_CGPA_ATTENDANCE.reg_id);
            return View(mPA_CGPA_ATTENDANCE);
        }

        // POST: MPA_CGPA_ATTENDANCE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,reg_id,attendance,cgpa")] MPA_CGPA_ATTENDANCE mPA_CGPA_ATTENDANCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_CGPA_ATTENDANCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_CGPA_ATTENDANCE.reg_id);
            return View(mPA_CGPA_ATTENDANCE);
        }

        // GET: MPA_CGPA_ATTENDANCE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_CGPA_ATTENDANCE mPA_CGPA_ATTENDANCE = db.MPA_CGPA_ATTENDANCE.Find(id);
            if (mPA_CGPA_ATTENDANCE == null)
            {
                return HttpNotFound();
            }
            return View(mPA_CGPA_ATTENDANCE);
        }

        // POST: MPA_CGPA_ATTENDANCE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_CGPA_ATTENDANCE mPA_CGPA_ATTENDANCE = db.MPA_CGPA_ATTENDANCE.Find(id);
            db.MPA_CGPA_ATTENDANCE.Remove(mPA_CGPA_ATTENDANCE);
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
