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
    public class SortiesController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Sorties
        public ActionResult Index()
        {
            var sorties = unitOfWork.SortieRepository.ObtenirSortiesCompletes();
            return View(sorties.ToList());
        }

        // GET: Sorties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = unitOfWork.SortieRepository.ObtenirSortieParID(id);
            if (sortie == null)
            {
                return HttpNotFound();
            }
            return View(sortie);
        }

        // GET: Sorties/Create
        public ActionResult Create()
        {
            ViewBag.CentreDeSkiId = new SelectList(unitOfWork.CentreDeSkiRepository.ObtenirCentreDeSki(), "CentreDeSkiId", "NomDuCentre");
            ViewBag.SaisonId = new SelectList(unitOfWork.SaisonRepository.GetSaisons(), "SaisonId", "SaisonId");
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
                unitOfWork.SortieRepository.Insert(sortie);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CentreDeSkiId = new SelectList(unitOfWork.CentreDeSkiRepository.ObtenirCentreDeSki(), "CentreDeSkiId", "NomDuCentre", sortie.CentreDeSkiId);
            ViewBag.SaisonId = new SelectList(unitOfWork.SaisonRepository.GetSaisons(), "SaisonId", "SaisonId", sortie.SaisonId);
            return View(sortie);
        }

        // GET: Sorties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = unitOfWork.SortieRepository.ObtenirSortieParID(id);
            if (sortie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentreDeSkiId = new SelectList(unitOfWork.CentreDeSkiRepository.ObtenirCentreDeSki(), "CentreDeSkiId", "NomDuCentre", sortie.CentreDeSkiId);
            ViewBag.SaisonId = new SelectList(unitOfWork.SaisonRepository.GetSaisons(), "SaisonId", "SaisonId", sortie.SaisonId);
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
                unitOfWork.SortieRepository.Update(sortie);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CentreDeSkiId = new SelectList(unitOfWork.CentreDeSkiRepository.ObtenirCentreDeSki(), "CentreDeSkiId", "NomDuCentre", sortie.CentreDeSkiId);
            ViewBag.SaisonId = new SelectList(unitOfWork.SaisonRepository.GetSaisons(), "SaisonId", "SaisonId", sortie.SaisonId);
            return View(sortie);
        }

        // GET: Sorties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sortie sortie = unitOfWork.SortieRepository.ObtenirSortieParID(id);
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
            Sortie sortie = unitOfWork.SortieRepository.ObtenirSortieParID(id);
            unitOfWork.SortieRepository.Delete(sortie);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
