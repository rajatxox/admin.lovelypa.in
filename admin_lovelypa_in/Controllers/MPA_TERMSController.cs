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
    public class MPA_TERMSController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_TERMS
        public ActionResult Index()
        {
            return View(db.MPA_TERMS.ToList());
        }

        // GET: MPA_TERMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TERMS mPA_TERMS = db.MPA_TERMS.Find(id);
            if (mPA_TERMS == null)
            {
                return HttpNotFound();
            }
            return View(mPA_TERMS);
        }

        // GET: MPA_TERMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MPA_TERMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,user_id,term_id,cgpa")] MPA_TERMS mPA_TERMS)
        {
            if (ModelState.IsValid)
            {
                db.MPA_TERMS.Add(mPA_TERMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mPA_TERMS);
        }

        // GET: MPA_TERMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TERMS mPA_TERMS = db.MPA_TERMS.Find(id);
            if (mPA_TERMS == null)
            {
                return HttpNotFound();
            }
            return View(mPA_TERMS);
        }

        // POST: MPA_TERMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,user_id,term_id,cgpa")] MPA_TERMS mPA_TERMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_TERMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mPA_TERMS);
        }

        // GET: MPA_TERMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_TERMS mPA_TERMS = db.MPA_TERMS.Find(id);
            if (mPA_TERMS == null)
            {
                return HttpNotFound();
            }
            return View(mPA_TERMS);
        }

        // POST: MPA_TERMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_TERMS mPA_TERMS = db.MPA_TERMS.Find(id);
            db.MPA_TERMS.Remove(mPA_TERMS);
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
