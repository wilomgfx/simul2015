using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab10.DAL;
using Lab10.Models;

namespace Lab10.Controllers
{
    public class UtilisateursController : Controller
    {
       // private Lab10Context db = new Lab10Context();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Utilisateurs
        public ActionResult Index()
        {
           // return View(db.Utilisateurs.ToList());
            return View(unitOfWork.UtilisateurRepository.Get().ToList());
        }

        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          //  Utilisateur utilisateur = db.Utilisateurs.Find(id);
            Utilisateur utilisateur = unitOfWork.UtilisateurRepository.GetByID(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }

               
            
             IEnumerable<Activite> lstActi = utilisateur.Activites.OrderByDescending(x => x.Date).Take(4);



             ViewBag.ListeTypeActivite = unitOfWork.TypeActiviteRepository.ObtenirTypeActivite();
             ViewBag.UtilActi = lstActi;


             //lstActi = unitOfWork.ActiviteRepository.ObtenirActivites().Where(x => x.Utilisateurs == utilisateur);
            //lstActi = unitOfWork.UtilisateurRepository

            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonneId,DateInscription,DateDebutContrat,DateFinContrat,Poids,NomPrenom,DateNaissance,Commentaire")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
               // db.Utilisateurs.Add(utilisateur);
                //db.SaveChanges();
                unitOfWork.UtilisateurRepository.Insert(utilisateur);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Utilisateur utilisateur = db.Utilisateurs.Find(id);
            Utilisateur utilisateur = unitOfWork.UtilisateurRepository.GetByID(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonneId,DateInscription,DateDebutContrat,DateFinContrat,Poids,NomPrenom,DateNaissance,Commentaire")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(utilisateur).State = EntityState.Modified;
                //db.SaveChanges();
                //unitOfWork.UtilisateurRepository.context.Entry(utilisateur).State = EntityState.Modified;
                unitOfWork.UtilisateurRepository.UpdateUtilisateur(utilisateur);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           // Utilisateur utilisateur = db.Utilisateurs.Find(id);
            Utilisateur utilisateur = unitOfWork.UtilisateurRepository.GetByID(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           //Utilisateur utilisateur = db.Utilisateurs.Find(id);
          //  db.Utilisateurs.Remove(utilisateur);
           // db.SaveChanges();
            Utilisateur utilisateur = unitOfWork.UtilisateurRepository.GetByID(id);
            unitOfWork.UtilisateurRepository.DeleteUtilisateur(utilisateur);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
