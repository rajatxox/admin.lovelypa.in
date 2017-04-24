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
    public class MPA_AI_QUESTIONSController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_AI_QUESTIONS
        public ActionResult Index()
        {
            return View(db.MPA_AI_QUESTIONS.ToList());
        }

        // GET: MPA_AI_QUESTIONS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_AI_QUESTIONS mPA_AI_QUESTIONS = db.MPA_AI_QUESTIONS.Find(id);
            if (mPA_AI_QUESTIONS == null)
            {
                return HttpNotFound();
            }
            return View(mPA_AI_QUESTIONS);
        }

        // GET: MPA_AI_QUESTIONS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MPA_AI_QUESTIONS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,question,command,priority")] MPA_AI_QUESTIONS mPA_AI_QUESTIONS)
        {
            if (ModelState.IsValid)
            {
                db.MPA_AI_QUESTIONS.Add(mPA_AI_QUESTIONS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mPA_AI_QUESTIONS);
        }

        // GET: MPA_AI_QUESTIONS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_AI_QUESTIONS mPA_AI_QUESTIONS = db.MPA_AI_QUESTIONS.Find(id);
            if (mPA_AI_QUESTIONS == null)
            {
                return HttpNotFound();
            }
            return View(mPA_AI_QUESTIONS);
        }

        // POST: MPA_AI_QUESTIONS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,question,command,priority")] MPA_AI_QUESTIONS mPA_AI_QUESTIONS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_AI_QUESTIONS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mPA_AI_QUESTIONS);
        }

        // GET: MPA_AI_QUESTIONS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_AI_QUESTIONS mPA_AI_QUESTIONS = db.MPA_AI_QUESTIONS.Find(id);
            if (mPA_AI_QUESTIONS == null)
            {
                return HttpNotFound();
            }
            return View(mPA_AI_QUESTIONS);
        }

        // POST: MPA_AI_QUESTIONS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_AI_QUESTIONS mPA_AI_QUESTIONS = db.MPA_AI_QUESTIONS.Find(id);
            db.MPA_AI_QUESTIONS.Remove(mPA_AI_QUESTIONS);
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
