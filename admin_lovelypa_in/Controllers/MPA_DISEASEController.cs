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
    public class MPA_DISEASEController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_DISEASE
        public ActionResult Index()
        {
            return View(db.MPA_DISEASE.ToList());
        }

        // GET: MPA_DISEASE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DISEASE mPA_DISEASE = db.MPA_DISEASE.Find(id);
            if (mPA_DISEASE == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DISEASE);
        }

        // GET: MPA_DISEASE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MPA_DISEASE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,disease")] MPA_DISEASE mPA_DISEASE)
        {
            if (ModelState.IsValid)
            {
                db.MPA_DISEASE.Add(mPA_DISEASE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mPA_DISEASE);
        }

        // GET: MPA_DISEASE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DISEASE mPA_DISEASE = db.MPA_DISEASE.Find(id);
            if (mPA_DISEASE == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DISEASE);
        }

        // POST: MPA_DISEASE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,disease")] MPA_DISEASE mPA_DISEASE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_DISEASE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mPA_DISEASE);
        }

        // GET: MPA_DISEASE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DISEASE mPA_DISEASE = db.MPA_DISEASE.Find(id);
            if (mPA_DISEASE == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DISEASE);
        }

        // POST: MPA_DISEASE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_DISEASE mPA_DISEASE = db.MPA_DISEASE.Find(id);
            db.MPA_DISEASE.Remove(mPA_DISEASE);
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
