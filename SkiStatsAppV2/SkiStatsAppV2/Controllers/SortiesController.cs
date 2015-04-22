﻿using System;
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
    public class SortiesController : Controller
    {
        private SkiStatsAppV2ContextDbContext db = new SkiStatsAppV2ContextDbContext();

        // GET: Sorties
        public ActionResult Index()
        {
            var sorties = db.Sorties.Include(s => s.CentreDeSki).Include(s => s.Saison);
            return View(sorties.ToList());
        }

        // GET: Sorties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = db.Sorties.Find(id);
            if (sortie == null)
            {
                return HttpNotFound();
            }
            return View(sortie);
        }

        // GET: Sorties/Create
        public ActionResult Create()
        {
            ViewBag.CentreDeSkiId = new SelectList(db.CentreDeSkis, "CentreDeSkiId", "NomDuCentre");
            ViewBag.SaisonId = new SelectList(db.Saisons, "SaisonId", "SaisonId");
            return View();
        }

        // POST: Sorties/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SortieId,SaisonId,CentreDeSkiId")] Sortie sortie)
        {
            if (ModelState.IsValid)
            {
                db.Sorties.Add(sortie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentreDeSkiId = new SelectList(db.CentreDeSkis, "CentreDeSkiId", "NomDuCentre", sortie.CentreDeSkiId);
            ViewBag.SaisonId = new SelectList(db.Saisons, "SaisonId", "SaisonId", sortie.SaisonId);
            return View(sortie);
        }

        // GET: Sorties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = db.Sorties.Find(id);
            if (sortie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentreDeSkiId = new SelectList(db.CentreDeSkis, "CentreDeSkiId", "NomDuCentre", sortie.CentreDeSkiId);
            ViewBag.SaisonId = new SelectList(db.Saisons, "SaisonId", "SaisonId", sortie.SaisonId);
            return View(sortie);
        }

        // POST: Sorties/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SortieId,SaisonId,CentreDeSkiId")] Sortie sortie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sortie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentreDeSkiId = new SelectList(db.CentreDeSkis, "CentreDeSkiId", "NomDuCentre", sortie.CentreDeSkiId);
            ViewBag.SaisonId = new SelectList(db.Saisons, "SaisonId", "SaisonId", sortie.SaisonId);
            return View(sortie);
        }

        // GET: Sorties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = db.Sorties.Find(id);
            if (sortie == null)
            {
                return HttpNotFound();
            }
            return View(sortie);
        }

        // POST: Sorties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sortie sortie = db.Sorties.Find(id);
            db.Sorties.Remove(sortie);
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
