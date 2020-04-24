using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransfusionNet.Storage;

namespace TransfusionNet.Controllers
{
    public class PuzzlesController : Controller
    {
        private DB db = new DB();

        // GET: Puzzles
        public ActionResult Index()
        {
            return View(db.Puzzles.ToList());
        }

        // GET: Puzzles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puzzle puzzle = db.Puzzles.Find(id);
            if (puzzle == null)
            {
                return HttpNotFound();
            }
            return View(puzzle);
        }

        // GET: Puzzles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puzzles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Puzzle puzzle)
        {
            if (ModelState.IsValid)
            {
                puzzle.ID = Guid.NewGuid();
                db.Puzzles.Add(puzzle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(puzzle);
        }

        // GET: Puzzles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puzzle puzzle = db.Puzzles.Find(id);
            if (puzzle == null)
            {
                return HttpNotFound();
            }
            return View(puzzle);
        }

        // POST: Puzzles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Puzzle puzzle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puzzle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puzzle);
        }

        // GET: Puzzles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puzzle puzzle = db.Puzzles.Find(id);
            if (puzzle == null)
            {
                return HttpNotFound();
            }
            return View(puzzle);
        }

        // POST: Puzzles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Puzzle puzzle = db.Puzzles.Find(id);
            db.Puzzles.Remove(puzzle);
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
