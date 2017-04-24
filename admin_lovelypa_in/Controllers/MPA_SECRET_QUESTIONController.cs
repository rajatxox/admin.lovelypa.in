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
    public class MPA_SECRET_QUESTIONController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_SECRET_QUESTION
        public ActionResult Index()
        {
            return View(db.MPA_SECRET_QUESTION.ToList());
        }

        // GET: MPA_SECRET_QUESTION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_SECRET_QUESTION mPA_SECRET_QUESTION = db.MPA_SECRET_QUESTION.Find(id);
            if (mPA_SECRET_QUESTION == null)
            {
                return HttpNotFound();
            }
            return View(mPA_SECRET_QUESTION);
        }

        // GET: MPA_SECRET_QUESTION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MPA_SECRET_QUESTION/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question")] MPA_SECRET_QUESTION mPA_SECRET_QUESTION)
        {
            if (ModelState.IsValid)
            {
                db.MPA_SECRET_QUESTION.Add(mPA_SECRET_QUESTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mPA_SECRET_QUESTION);
        }

        // GET: MPA_SECRET_QUESTION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_SECRET_QUESTION mPA_SECRET_QUESTION = db.MPA_SECRET_QUESTION.Find(id);
            if (mPA_SECRET_QUESTION == null)
            {
                return HttpNotFound();
            }
            return View(mPA_SECRET_QUESTION);
        }

        // POST: MPA_SECRET_QUESTION/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question")] MPA_SECRET_QUESTION mPA_SECRET_QUESTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_SECRET_QUESTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mPA_SECRET_QUESTION);
        }

        // GET: MPA_SECRET_QUESTION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_SECRET_QUESTION mPA_SECRET_QUESTION = db.MPA_SECRET_QUESTION.Find(id);
            if (mPA_SECRET_QUESTION == null)
            {
                return HttpNotFound();
            }
            return View(mPA_SECRET_QUESTION);
        }

        // POST: MPA_SECRET_QUESTION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_SECRET_QUESTION mPA_SECRET_QUESTION = db.MPA_SECRET_QUESTION.Find(id);
            db.MPA_SECRET_QUESTION.Remove(mPA_SECRET_QUESTION);
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
