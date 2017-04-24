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
    public class MPA_DETAILED_SYMPTOMController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_DETAILED_SYMPTOM
        public ActionResult Index()
        {
            var mPA_DETAILED_SYMPTOM = db.MPA_DETAILED_SYMPTOM.Include(m => m.MPA_BASIC_SYMPTOM);
            return View(mPA_DETAILED_SYMPTOM.ToList());
        }

        // GET: MPA_DETAILED_SYMPTOM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DETAILED_SYMPTOM mPA_DETAILED_SYMPTOM = db.MPA_DETAILED_SYMPTOM.Find(id);
            if (mPA_DETAILED_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DETAILED_SYMPTOM);
        }

        // GET: MPA_DETAILED_SYMPTOM/Create
        public ActionResult Create()
        {
            ViewBag.basic_symptom_Id = new SelectList(db.MPA_BASIC_SYMPTOM, "id", "symptom");
            return View();
        }

        // POST: MPA_DETAILED_SYMPTOM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,basic_symptom_Id,detailed_symptom,priority")] MPA_DETAILED_SYMPTOM mPA_DETAILED_SYMPTOM)
        {
            if (ModelState.IsValid)
            {
                db.MPA_DETAILED_SYMPTOM.Add(mPA_DETAILED_SYMPTOM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.basic_symptom_Id = new SelectList(db.MPA_BASIC_SYMPTOM, "id", "symptom", mPA_DETAILED_SYMPTOM.basic_symptom_Id);
            return View(mPA_DETAILED_SYMPTOM);
        }

        // GET: MPA_DETAILED_SYMPTOM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DETAILED_SYMPTOM mPA_DETAILED_SYMPTOM = db.MPA_DETAILED_SYMPTOM.Find(id);
            if (mPA_DETAILED_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            ViewBag.basic_symptom_Id = new SelectList(db.MPA_BASIC_SYMPTOM, "id", "symptom", mPA_DETAILED_SYMPTOM.basic_symptom_Id);
            return View(mPA_DETAILED_SYMPTOM);
        }

        // POST: MPA_DETAILED_SYMPTOM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,basic_symptom_Id,detailed_symptom,priority")] MPA_DETAILED_SYMPTOM mPA_DETAILED_SYMPTOM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_DETAILED_SYMPTOM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.basic_symptom_Id = new SelectList(db.MPA_BASIC_SYMPTOM, "id", "symptom", mPA_DETAILED_SYMPTOM.basic_symptom_Id);
            return View(mPA_DETAILED_SYMPTOM);
        }

        // GET: MPA_DETAILED_SYMPTOM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DETAILED_SYMPTOM mPA_DETAILED_SYMPTOM = db.MPA_DETAILED_SYMPTOM.Find(id);
            if (mPA_DETAILED_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DETAILED_SYMPTOM);
        }

        // POST: MPA_DETAILED_SYMPTOM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_DETAILED_SYMPTOM mPA_DETAILED_SYMPTOM = db.MPA_DETAILED_SYMPTOM.Find(id);
            db.MPA_DETAILED_SYMPTOM.Remove(mPA_DETAILED_SYMPTOM);
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
