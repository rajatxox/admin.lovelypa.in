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
    public class MPA_TERM_DATAController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_TERM_DATA
        public ActionResult Index()
        {
            var mPA_TERM_DATA = db.MPA_TERM_DATA.Include(m => m.MPA_TERMS);
            return View(mPA_TERM_DATA.ToList());
        }

        // GET: MPA_TERM_DATA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TERM_DATA mPA_TERM_DATA = db.MPA_TERM_DATA.Find(id);
            if (mPA_TERM_DATA == null)
            {
                return HttpNotFound();
            }
            return View(mPA_TERM_DATA);
        }

        // GET: MPA_TERM_DATA/Create
        public ActionResult Create()
        {
            ViewBag.term_id = new SelectList(db.MPA_TERMS, "id", "id");
            return View();
        }

        // POST: MPA_TERM_DATA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,term_id,subject_name,subject_code,credit,grade")] MPA_TERM_DATA mPA_TERM_DATA)
        {
            if (ModelState.IsValid)
            {
                db.MPA_TERM_DATA.Add(mPA_TERM_DATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.term_id = new SelectList(db.MPA_TERMS, "id", "id", mPA_TERM_DATA.term_id);
            return View(mPA_TERM_DATA);
        }

        // GET: MPA_TERM_DATA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TERM_DATA mPA_TERM_DATA = db.MPA_TERM_DATA.Find(id);
            if (mPA_TERM_DATA == null)
            {
                return HttpNotFound();
            }
            ViewBag.term_id = new SelectList(db.MPA_TERMS, "id", "id", mPA_TERM_DATA.term_id);
            return View(mPA_TERM_DATA);
        }

        // POST: MPA_TERM_DATA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,term_id,subject_name,subject_code,credit,grade")] MPA_TERM_DATA mPA_TERM_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_TERM_DATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.term_id = new SelectList(db.MPA_TERMS, "id", "id", mPA_TERM_DATA.term_id);
            return View(mPA_TERM_DATA);
        }

        // GET: MPA_TERM_DATA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TERM_DATA mPA_TERM_DATA = db.MPA_TERM_DATA.Find(id);
            if (mPA_TERM_DATA == null)
            {
                return HttpNotFound();
            }
            return View(mPA_TERM_DATA);
        }

        // POST: MPA_TERM_DATA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_TERM_DATA mPA_TERM_DATA = db.MPA_TERM_DATA.Find(id);
            db.MPA_TERM_DATA.Remove(mPA_TERM_DATA);
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
