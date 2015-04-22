using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkiStatsAppV2.DAL;
using SkiStatsAppV2.Models;

namespace SkiStatsAppV2.Controllers
{
    public class DescentesController : Controller
    {
        private SkiStatsAppV2ContextDbContext db = new SkiStatsAppV2ContextDbContext();

        // GET: Descentes
        public ActionResult Index()
        {
            var descentes = db.Descentes.Include(d => d.Sortie);
            return View(descentes.ToList());
        }

        // GET: Descentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descente descente = db.Descentes.Find(id);
            if (descente == null)
            {
                return HttpNotFound();
            }
            return View(descente);
        }

        // GET: Descentes/Create
        public ActionResult Create()
        {
            ViewBag.SortieId = new SelectList(db.Sorties, "SortieId", "SortieId");
            return View();
        }

        // POST: Descentes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DescenteId,SortieId")] Descente descente)
        {
            if (ModelState.IsValid)
            {
                db.Descentes.Add(descente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SortieId = new SelectList(db.Sorties, "SortieId", "SortieId", descente.SortieId);
            return View(descente);
        }

        // GET: Descentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descente descente = db.Descentes.Find(id);
            if (descente == null)
            {
                return HttpNotFound();
            }
            ViewBag.SortieId = new SelectList(db.Sorties, "SortieId", "SortieId", descente.SortieId);
            return View(descente);
        }

        // POST: Descentes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DescenteId,SortieId")] Descente descente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SortieId = new SelectList(db.Sorties, "SortieId", "SortieId", descente.SortieId);
            return View(descente);
        }

        // GET: Descentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descente descente = db.Descentes.Find(id);
            if (descente == null)
            {
                return HttpNotFound();
            }
            return View(descente);
        }

        // POST: Descentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Descente descente = db.Descentes.Find(id);
            db.Descentes.Remove(descente);
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
