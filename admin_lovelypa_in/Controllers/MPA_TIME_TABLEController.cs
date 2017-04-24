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
    public class MPA_TIME_TABLEController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_TIME_TABLE
        public ActionResult Index()
        {
            var mPA_TIME_TABLE = db.MPA_TIME_TABLE.Include(m => m.MPA_USER_DATA);
            return View(mPA_TIME_TABLE.ToList());
        }

        // GET: MPA_TIME_TABLE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TIME_TABLE mPA_TIME_TABLE = db.MPA_TIME_TABLE.Find(id);
            if (mPA_TIME_TABLE == null)
            {
                return HttpNotFound();
            }
            return View(mPA_TIME_TABLE);
        }

        // GET: MPA_TIME_TABLE/Create
        public ActionResult Create()
        {
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name");
            return View();
        }

        // POST: MPA_TIME_TABLE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,reg_id,class_type,time_from,time_to,day,subject_code,room_number")] MPA_TIME_TABLE mPA_TIME_TABLE)
        {
            if (ModelState.IsValid)
            {
                db.MPA_TIME_TABLE.Add(mPA_TIME_TABLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_TIME_TABLE.reg_id);
            return View(mPA_TIME_TABLE);
        }

        // GET: MPA_TIME_TABLE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TIME_TABLE mPA_TIME_TABLE = db.MPA_TIME_TABLE.Find(id);
            if (mPA_TIME_TABLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_TIME_TABLE.reg_id);
            return View(mPA_TIME_TABLE);
        }

        // POST: MPA_TIME_TABLE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,reg_id,class_type,time_from,time_to,day,subject_code,room_number")] MPA_TIME_TABLE mPA_TIME_TABLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_TIME_TABLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.reg_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_TIME_TABLE.reg_id);
            return View(mPA_TIME_TABLE);
        }

        // GET: MPA_TIME_TABLE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TIME_TABLE mPA_TIME_TABLE = db.MPA_TIME_TABLE.Find(id);
            if (mPA_TIME_TABLE == null)
            {
                return HttpNotFound();
            }
            return View(mPA_TIME_TABLE);
        }

        // POST: MPA_TIME_TABLE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_TIME_TABLE mPA_TIME_TABLE = db.MPA_TIME_TABLE.Find(id);
            db.MPA_TIME_TABLE.Remove(mPA_TIME_TABLE);
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
