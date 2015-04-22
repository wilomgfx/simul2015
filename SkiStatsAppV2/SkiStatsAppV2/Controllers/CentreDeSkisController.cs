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
    public class CentreDeSkisController : Controller
    {
        //private SkiStatsAppV2ContextDbContext db = new SkiStatsAppV2ContextDbContext();

        private UnitOfWork uow = new UnitOfWork();

        // GET: CentreDeSkis
        public ActionResult Index()
        {
            //var centreDeSkis = db.CentreDeSkis.Include(c => c.Region);
            var centreDeSkis = uow.CentreDeSkiRepository.ObtenirCentreDeSki();
            return View(centreDeSkis.ToList());
        }

        // GET: CentreDeSkis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentreDeSki centreDeSki = db.CentreDeSkis.Find(id);
            CentreDeSki centreDeSki = uow.CentreDeSkiRepository.ObtenirCentreDeSkiParID(id);
            if (centreDeSki == null)
            {
                return HttpNotFound();
            }
            return View(centreDeSki);
        }

        // GET: CentreDeSkis/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(uow.RegionRepository.GetRegions(), "RegionId", "Nom");
            return View();
        }

        // POST: CentreDeSkis/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentreDeSkiId,NomDuCentre,RegionId")] CentreDeSki centreDeSki)
        {
            if (ModelState.IsValid)
            {
                //db.CentreDeSkis.Add(centreDeSki);
                //db.SaveChanges();
                uow.CentreDeSkiRepository.Insert(centreDeSki);
                uow.Save();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(uow.RegionRepository.GetRegions(), "RegionId", "Nom", centreDeSki.RegionId);
            return View(centreDeSki);
        }

        // GET: CentreDeSkis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentreDeSki centreDeSki = db.CentreDeSkis.Find(id);
            CentreDeSki centreDeSki = uow.CentreDeSkiRepository.ObtenirCentreDeSkiParID(id);
            if (centreDeSki == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(uow.RegionRepository.GetRegions(), "RegionId", "Nom", centreDeSki.RegionId);
            return View(centreDeSki);
        }

        // POST: CentreDeSkis/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentreDeSkiId,NomDuCentre,RegionId")] CentreDeSki centreDeSki)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(centreDeSki).State = EntityState.Modified;
                //db.SaveChanges();
                uow.CentreDeSkiRepository.Update(centreDeSki);
                uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(uow.RegionRepository.GetRegions(), "RegionId", "Nom", centreDeSki.RegionId);
            return View(centreDeSki);
        }

        // GET: CentreDeSkis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentreDeSki centreDeSki = db.CentreDeSkis.Find(id);
            CentreDeSki centreDeSki = uow.CentreDeSkiRepository.ObtenirCentreDeSkiParID(id);
            if (centreDeSki == null)
            {
                return HttpNotFound();
            }
            return View(centreDeSki);
        }

        // POST: CentreDeSkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CentreDeSki centreDeSki = db.CentreDeSkis.Find(id);
            CentreDeSki centreDeSki = uow.CentreDeSkiRepository.ObtenirCentreDeSkiParID(id);
            //db.CentreDeSkis.Remove(centreDeSki);
            //db.SaveChanges();
            uow.CentreDeSkiRepository.Delete(centreDeSki);
            uow.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
