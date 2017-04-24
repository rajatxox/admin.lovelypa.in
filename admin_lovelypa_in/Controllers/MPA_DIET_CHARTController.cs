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
    public class MPA_DIET_CHARTController : Controller
    {
        private MPA_DATA db = new MPA_DATA();

        // GET: MPA_DIET_CHART
        public ActionResult Index()
        {
            return View(db.MPA_DIET_CHART.ToList());
        }

        // GET: MPA_DIET_CHART/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DIET_CHART mPA_DIET_CHART = db.MPA_DIET_CHART.Find(id);
            if (mPA_DIET_CHART == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DIET_CHART);
        }

        // GET: MPA_DIET_CHART/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MPA_DIET_CHART/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,item_name,calories,carbohydrate,protein,cholesterol,fat")] MPA_DIET_CHART mPA_DIET_CHART)
        {
            if (ModelState.IsValid)
            {
                db.MPA_DIET_CHART.Add(mPA_DIET_CHART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mPA_DIET_CHART);
        }

        // GET: MPA_DIET_CHART/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DIET_CHART mPA_DIET_CHART = db.MPA_DIET_CHART.Find(id);
            if (mPA_DIET_CHART == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DIET_CHART);
        }

        // POST: MPA_DIET_CHART/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,item_name,calories,carbohydrate,protein,cholesterol,fat")] MPA_DIET_CHART mPA_DIET_CHART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPA_DIET_CHART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mPA_DIET_CHART);
        }

        // GET: MPA_DIET_CHART/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPA_DIET_CHART mPA_DIET_CHART = db.MPA_DIET_CHART.Find(id);
            if (mPA_DIET_CHART == null)
            {
                return HttpNotFound();
            }
            return View(mPA_DIET_CHART);
        }

        // POST: MPA_DIET_CHART/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPA_DIET_CHART mPA_DIET_CHART = db.MPA_DIET_CHART.Find(id);
            db.MPA_DIET_CHART.Remove(mPA_DIET_CHART);
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
