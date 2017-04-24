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
    public class MPA_USER_DATAController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_USER_DATA
        public ActionResult Index()
        {
            return View(db.MPA_USER_DATA.ToList());
        }

        // GET: MPA_USER_DATA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_USER_DATA mPA_USER_DATA = db.MPA_USER_DATA.Find(id);
            if (mPA_USER_DATA == null)
            {
                return HttpNotFound();
            }
            return View(mPA_USER_DATA);
        }

        // GET: MPA_USER_DATA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MPA_USER_DATA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,date_of_birth,email_id,phone_number,password,security_question,security_answer,profile_pic,height,weight")] MPA_USER_DATA mPA_USER_DATA)
        {
            if (ModelState.IsValid)
            {
                db.MPA_USER_DATA.Add(mPA_USER_DATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mPA_USER_DATA);
        }

        // GET: MPA_USER_DATA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_USER_DATA mPA_USER_DATA = db.MPA_USER_DATA.Find(id);
            if (mPA_USER_DATA == null)
            {
                return HttpNotFound();
            }
            return View(mPA_USER_DATA);
        }

        // POST: MPA_USER_DATA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,date_of_birth,email_id,phone_number,password,security_question,security_answer,profile_pic,height,weight")] MPA_USER_DATA mPA_USER_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_USER_DATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mPA_USER_DATA);
        }

        // GET: MPA_USER_DATA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_USER_DATA mPA_USER_DATA = db.MPA_USER_DATA.Find(id);
            if (mPA_USER_DATA == null)
            {
                return HttpNotFound();
            }
            return View(mPA_USER_DATA);
        }

        // POST: MPA_USER_DATA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MPA_USER_DATA mPA_USER_DATA = db.MPA_USER_DATA.Find(id);
            db.MPA_USER_DATA.Remove(mPA_USER_DATA);
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
