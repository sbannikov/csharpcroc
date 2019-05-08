using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeaBattle;

namespace SeaBattleMvc.Controllers
{
    public class CoreTestDataController : Controller
    {
        private DB db = new DB();

        // GET: CoreTestData
        public ActionResult Index()
        {
            return View(db.Data
                .OrderBy(a=>a.X1)
                .ThenBy(a=>a.Y1)
                .ThenBy(a => a.X2)
                .ThenBy(a => a.Y2)
                .ToList());
        }

        // GET: CoreTestData/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreTestData coreTestData = db.Data.Find(id);
            if (coreTestData == null)
            {
                return HttpNotFound();
            }
            return View(coreTestData);
        }

        // GET: CoreTestData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoreTestData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,X1,Y1,X2,Y2,Result")] CoreTestData coreTestData)
        {
            if (ModelState.IsValid)
            {
                coreTestData.ID = Guid.NewGuid();
                db.Data.Add(coreTestData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coreTestData);
        }

        // GET: CoreTestData/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreTestData coreTestData = db.Data.Find(id);
            if (coreTestData == null)
            {
                return HttpNotFound();
            }
            return View(coreTestData);
        }

        // POST: CoreTestData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,X1,Y1,X2,Y2,Result")] CoreTestData coreTestData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreTestData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coreTestData);
        }

        // GET: CoreTestData/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreTestData coreTestData = db.Data.Find(id);
            if (coreTestData == null)
            {
                return HttpNotFound();
            }
            return View(coreTestData);
        }

        // POST: CoreTestData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CoreTestData coreTestData = db.Data.Find(id);
            db.Data.Remove(coreTestData);
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
