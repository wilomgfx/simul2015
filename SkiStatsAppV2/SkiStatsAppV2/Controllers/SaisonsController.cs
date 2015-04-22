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
using SkiStatsAppV2.ViewModels;

namespace SkiStatsAppV2.Controllers
{
    public class SaisonsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Saisons
        public ActionResult Index()
        {
            return View(unitOfWork.SaisonRepository.GetSaisons().ToList());
        }

        public ActionResult StatistiquesSaisonGenerale()
        {
            IEnumerable<Saison> saisons = unitOfWork.SaisonRepository.GetSaisons();
            List<StatsSaisonGenerale> lst = new List<StatsSaisonGenerale>();

            foreach (Saison s in saisons)
            {
                StatsSaisonGenerale stats = new StatsSaisonGenerale();

                stats.Saison = s;
                stats.nbrDaysSkiing = unitOfWork.SaisonRepository.ObtenirNombreDeJoursSkier(s);
                stats.nbrDifferentSkiAreas = unitOfWork.SaisonRepository.ObtenirNombreDeDifferenteRegionsSkier(s);
                stats.nbrNewSkiAreas = unitOfWork.SaisonRepository.ObtenirNombreDeNouvelleRegionsSkier(s);
                stats.totalVerticalFeet = unitOfWork.SaisonRepository.ObtenirNombreDePiedsVerticaux(s);
                stats.nbrOfRuns = unitOfWork.SaisonRepository.ObtenirNombreDeDescente(s);
                stats.avgRunsPerDay = unitOfWork.SaisonRepository.ObtenirAverageRunsPerDay(s.SaisonId);
                stats.avgFeetPerDay = unitOfWork.SaisonRepository.ObtenirAverageFeetPerDay(s.SaisonId);
                stats.avgFeetPerRun = unitOfWork.SaisonRepository.ObtenirAverageFeetPerRun(s.SaisonId);
                stats.firstDayOfSkiing = unitOfWork.SaisonRepository.ObtenirPremiereJourneeDeSki(s.SaisonId);
                stats.firstDateOfSkiing = unitOfWork.SaisonRepository.ObtenirPremiereDateDeSki(s.SaisonId);
                stats.firstSkiArea = unitOfWork.SaisonRepository.FirstSkiArea(s);
                stats.lastDayOfSkiing = unitOfWork.SaisonRepository.LastDaySkiingDD(s);
                stats.lastDateOfSkiing = unitOfWork.SaisonRepository.LastDaySkiingMMdd(s);
                stats.lastSkiArea = unitOfWork.SaisonRepository.LastSkiArea(s);
                stats.lengthOfSeason = unitOfWork.SaisonRepository.LougueurSaison(s);
                stats.avgElapsedDays = unitOfWork.SaisonRepository.moyenneDesJoursEntreDeuxSorties(s);

                lst.Add(stats);
            }

            CollectionDeStats col = new CollectionDeStats();
            col.Saisons = lst;

            return View(col);
        }

        // GET: Saisons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saison saison = unitOfWork.SaisonRepository.GetByID(id);
            if (saison == null)
            {
                return HttpNotFound();
            }
            return View(saison);
        }

        // GET: Saisons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saisons/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaisonId,Annee")] Saison saison)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SaisonRepository.Insert(saison);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(saison);
        }

        // GET: Saisons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saison saison = unitOfWork.SaisonRepository.GetByID(id);
            if (saison == null)
            {
                return HttpNotFound();
            }
            return View(saison);
        }

        // POST: Saisons/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaisonId,Annee")] Saison saison)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SaisonRepository.UpdateSaison(saison);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(saison);
        }

        // GET: Saisons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saison saison = unitOfWork.SaisonRepository.GetByID(id);
            if (saison == null)
            {
                return HttpNotFound();
            }
            return View(saison);
        }

        // POST: Saisons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saison saison = unitOfWork.SaisonRepository.GetByID(id);
            unitOfWork.SaisonRepository.DeleteSaison(saison);
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
