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
    public class MPA_USER_DIET_PLANController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_USER_DIET_PLAN
        public ActionResult Index()
        {
            var mPA_USER_DIET_PLAN = db.MPA_USER_DIET_PLAN.Include(m => m.MPA_USER_DATA);
            return View(mPA_USER_DIET_PLAN.ToList());
        }

        // GET: MPA_USER_DIET_PLAN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_USER_DIET_PLAN mPA_USER_DIET_PLAN = db.MPA_USER_DIET_PLAN.Find(id);
            if (mPA_USER_DIET_PLAN == null)
            {
                return HttpNotFound();
            }
            return View(mPA_USER_DIET_PLAN);
        }

        // GET: MPA_USER_DIET_PLAN/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name");
            return View();
        }

        // POST: MPA_USER_DIET_PLAN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,user_id,calories,carbohydrate,protein,cholesterol,fat")] MPA_USER_DIET_PLAN mPA_USER_DIET_PLAN)
        {
            if (ModelState.IsValid)
            {
                db.MPA_USER_DIET_PLAN.Add(mPA_USER_DIET_PLAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_USER_DIET_PLAN.user_id);
            return View(mPA_USER_DIET_PLAN);
        }

        // GET: MPA_USER_DIET_PLAN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_USER_DIET_PLAN mPA_USER_DIET_PLAN = db.MPA_USER_DIET_PLAN.Find(id);
            if (mPA_USER_DIET_PLAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_USER_DIET_PLAN.user_id);
            return View(mPA_USER_DIET_PLAN);
        }

        // POST: MPA_USER_DIET_PLAN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,user_id,calories,carbohydrate,protein,cholesterol,fat")] MPA_USER_DIET_PLAN mPA_USER_DIET_PLAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_USER_DIET_PLAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_USER_DIET_PLAN.user_id);
            return View(mPA_USER_DIET_PLAN);
        }

        // GET: MPA_USER_DIET_PLAN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_USER_DIET_PLAN mPA_USER_DIET_PLAN = db.MPA_USER_DIET_PLAN.Find(id);
            if (mPA_USER_DIET_PLAN == null)
            {
                return HttpNotFound();
            }
            return View(mPA_USER_DIET_PLAN);
        }

        // POST: MPA_USER_DIET_PLAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_USER_DIET_PLAN mPA_USER_DIET_PLAN = db.MPA_USER_DIET_PLAN.Find(id);
            db.MPA_USER_DIET_PLAN.Remove(mPA_USER_DIET_PLAN);
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
