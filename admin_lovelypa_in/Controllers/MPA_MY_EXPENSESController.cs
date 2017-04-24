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
    public class MPA_MY_EXPENSESController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_MY_EXPENSES
        public ActionResult Index()
        {
            var mPA_MY_EXPENSES = db.MPA_MY_EXPENSES.Include(m => m.MPA_USER_DATA);
            return View(mPA_MY_EXPENSES.ToList());
        }

        // GET: MPA_MY_EXPENSES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_MY_EXPENSES mPA_MY_EXPENSES = db.MPA_MY_EXPENSES.Find(id);
            if (mPA_MY_EXPENSES == null)
            {
                return HttpNotFound();
            }
            return View(mPA_MY_EXPENSES);
        }

        // GET: MPA_MY_EXPENSES/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name");
            return View();
        }

        // POST: MPA_MY_EXPENSES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,user_id,item_name,date,time,price")] MPA_MY_EXPENSES mPA_MY_EXPENSES)
        {
            if (ModelState.IsValid)
            {
                db.MPA_MY_EXPENSES.Add(mPA_MY_EXPENSES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_MY_EXPENSES.user_id);
            return View(mPA_MY_EXPENSES);
        }

        // GET: MPA_MY_EXPENSES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_MY_EXPENSES mPA_MY_EXPENSES = db.MPA_MY_EXPENSES.Find(id);
            if (mPA_MY_EXPENSES == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_MY_EXPENSES.user_id);
            return View(mPA_MY_EXPENSES);
        }

        // POST: MPA_MY_EXPENSES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,user_id,item_name,date,time,price")] MPA_MY_EXPENSES mPA_MY_EXPENSES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_MY_EXPENSES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.MPA_USER_DATA, "user_id", "user_name", mPA_MY_EXPENSES.user_id);
            return View(mPA_MY_EXPENSES);
        }

        // GET: MPA_MY_EXPENSES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_MY_EXPENSES mPA_MY_EXPENSES = db.MPA_MY_EXPENSES.Find(id);
            if (mPA_MY_EXPENSES == null)
            {
                return HttpNotFound();
            }
            return View(mPA_MY_EXPENSES);
        }

        // POST: MPA_MY_EXPENSES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_MY_EXPENSES mPA_MY_EXPENSES = db.MPA_MY_EXPENSES.Find(id);
            db.MPA_MY_EXPENSES.Remove(mPA_MY_EXPENSES);
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
