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
    public class MPA_DISEASE_BASIC_SYMPTOMController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_DISEASE_BASIC_SYMPTOM
        public ActionResult Index()
        {
            var mPA_DISEASE_BASIC_SYMPTOM = db.MPA_DISEASE_BASIC_SYMPTOM.Include(m => m.MPA_BASIC_SYMPTOM).Include(m => m.MPA_DISEASE);
            return View(mPA_DISEASE_BASIC_SYMPTOM.ToList());
        }

        // GET: MPA_DISEASE_BASIC_SYMPTOM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DISEASE_BASIC_SYMPTOM mPA_DISEASE_BASIC_SYMPTOM = db.MPA_DISEASE_BASIC_SYMPTOM.Find(id);
            if (mPA_DISEASE_BASIC_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DISEASE_BASIC_SYMPTOM);
        }

        // GET: MPA_DISEASE_BASIC_SYMPTOM/Create
        public ActionResult Create()
        {
            ViewBag.basic_symptom_id = new SelectList(db.MPA_BASIC_SYMPTOM, "id", "symptom");
            ViewBag.disease_id = new SelectList(db.MPA_DISEASE, "id", "disease");
            return View();
        }

        // POST: MPA_DISEASE_BASIC_SYMPTOM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,disease_id,basic_symptom_id,percentage")] MPA_DISEASE_BASIC_SYMPTOM mPA_DISEASE_BASIC_SYMPTOM)
        {
            if (ModelState.IsValid)
            {
                db.MPA_DISEASE_BASIC_SYMPTOM.Add(mPA_DISEASE_BASIC_SYMPTOM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.basic_symptom_id = new SelectList(db.MPA_BASIC_SYMPTOM, "id", "symptom", mPA_DISEASE_BASIC_SYMPTOM.basic_symptom_id);
            ViewBag.disease_id = new SelectList(db.MPA_DISEASE, "id", "disease", mPA_DISEASE_BASIC_SYMPTOM.disease_id);
            return View(mPA_DISEASE_BASIC_SYMPTOM);
        }

        // GET: MPA_DISEASE_BASIC_SYMPTOM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DISEASE_BASIC_SYMPTOM mPA_DISEASE_BASIC_SYMPTOM = db.MPA_DISEASE_BASIC_SYMPTOM.Find(id);
            if (mPA_DISEASE_BASIC_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            ViewBag.basic_symptom_id = new SelectList(db.MPA_BASIC_SYMPTOM, "id", "symptom", mPA_DISEASE_BASIC_SYMPTOM.basic_symptom_id);
            ViewBag.disease_id = new SelectList(db.MPA_DISEASE, "id", "disease", mPA_DISEASE_BASIC_SYMPTOM.disease_id);
            return View(mPA_DISEASE_BASIC_SYMPTOM);
        }

        // POST: MPA_DISEASE_BASIC_SYMPTOM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,disease_id,basic_symptom_id,percentage")] MPA_DISEASE_BASIC_SYMPTOM mPA_DISEASE_BASIC_SYMPTOM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_DISEASE_BASIC_SYMPTOM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.basic_symptom_id = new SelectList(db.MPA_BASIC_SYMPTOM, "id", "symptom", mPA_DISEASE_BASIC_SYMPTOM.basic_symptom_id);
            ViewBag.disease_id = new SelectList(db.MPA_DISEASE, "id", "disease", mPA_DISEASE_BASIC_SYMPTOM.disease_id);
            return View(mPA_DISEASE_BASIC_SYMPTOM);
        }

        // GET: MPA_DISEASE_BASIC_SYMPTOM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DISEASE_BASIC_SYMPTOM mPA_DISEASE_BASIC_SYMPTOM = db.MPA_DISEASE_BASIC_SYMPTOM.Find(id);
            if (mPA_DISEASE_BASIC_SYMPTOM == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DISEASE_BASIC_SYMPTOM);
        }

        // POST: MPA_DISEASE_BASIC_SYMPTOM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_DISEASE_BASIC_SYMPTOM mPA_DISEASE_BASIC_SYMPTOM = db.MPA_DISEASE_BASIC_SYMPTOM.Find(id);
            db.MPA_DISEASE_BASIC_SYMPTOM.Remove(mPA_DISEASE_BASIC_SYMPTOM);
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
