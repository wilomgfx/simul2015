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
    public class SaisonsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Saisons
        public ActionResult Index()
        {
            return View(unitOfWork.SaisonRepository.GetSaisons().ToList());
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
