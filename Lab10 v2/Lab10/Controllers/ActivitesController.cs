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
    public class ActivitesController : Controller
    {
        //private Lab10Context db = new Lab10Context();
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Activites
        public ActionResult Index()
        {
            //return View(db.Activite.ToList());
            return View(unitOfWork.ActiviteRepository.Get().ToList());
        }

        // GET: Activites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Activite activite = db.Activite.Find(id);
            Activite activite = unitOfWork.ActiviteRepository.GetByID(id);
            if (activite == null)
            {
                return HttpNotFound();
            }


           



            return View(activite);
        }

        // GET: Activites/Create
        public ActionResult Create()
        {
            ICollection<int> indexes = new List<int>();
            foreach (var item in unitOfWork.UtilisateurRepository.Get())
            {
                indexes.Add(item.PersonneId);
            }

            ICollection<int> indexTypeActivite = new List<int>();
            foreach (var item in unitOfWork.TypeActiviteRepository.Get())
            {
                indexTypeActivite.Add(item.TypeActiviteId);
            }


            ViewBag.UtilActivite = new MultiSelectList(unitOfWork.UtilisateurRepository.ObtenirUtilisateurs(), "PersonneId", "NomPrenom", indexes);
            ViewBag.TypeActivite = new SelectList(unitOfWork.TypeActiviteRepository.Get(), "TypeActiviteID", "NomActivite", indexTypeActivite);
            return View();
        }

        // POST: Activites/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActiviteId,Duree,Date")] Activite activite, FormCollection Collection)
        {
            if (ModelState.IsValid)
            {
               // db.Activite.Add(activite);
                //db.SaveChanges();


                string[] tabIndexes = Collection["UtilActivite"].ToString().Split(',');
                ICollection<Utilisateur> list = new List<Utilisateur>();

                for (int i = 0; i < tabIndexes.Length; i++)
                {
                    int indexReally = int.Parse(tabIndexes[i]);
                    list.Add(unitOfWork.UtilisateurRepository.GetByID(indexReally));
                }

                TypeActivite typeActi = unitOfWork.TypeActiviteRepository.ObtenirTypeActiviteParID(int.Parse(Collection["TypeActivite"]));


                activite.TypeActivite = typeActi;
                activite.Utilisateurs = list;

                unitOfWork.ActiviteRepository.Insert(activite);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
           
            return View(activite);
        }

        // GET: Activites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Activite activite = db.Activite.Find(id);
            Activite activite = unitOfWork.ActiviteRepository.GetByID(id);
            if (activite == null)
            {
                return HttpNotFound();
            }

            ICollection<int> indexes = new List<int>();
            foreach(var item in activite.Utilisateurs)
            {
                indexes.Add(item.PersonneId);
            }
            ViewBag.UtilActivite = new MultiSelectList(unitOfWork.UtilisateurRepository.ObtenirUtilisateurs(), "PersonneId", "NomPrenom", indexes);         
            ViewBag.TypeActivite = new SelectList(unitOfWork.TypeActiviteRepository.Get(), "TypeActiviteID", "NomActivite", activite.TypeActivite.TypeActiviteId);

            return View(activite);
        }

        // POST: Activites/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActiviteId,Duree,Date")] Activite activite, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                string[] tabIndexes = collection["UtilActivite"].ToString().Split(',');
                ICollection<Utilisateur> list = new List<Utilisateur>();

                for (int i = 0; i < tabIndexes.Length; i++)
                {
                    int indexReally = int.Parse(tabIndexes[i]);
                    list.Add(unitOfWork.UtilisateurRepository.GetByID(indexReally));
                }
                int indexActivite = int.Parse(collection["ActiviteID"]);
                Activite acti = unitOfWork.ActiviteRepository.ObtenirActiviteParID(indexActivite);
                TypeActivite typeActi = unitOfWork.TypeActiviteRepository.ObtenirTypeActiviteParID(int.Parse(collection["TypeActivite"]));
                
                
                acti.Utilisateurs.Clear();
                acti.Utilisateurs = list;

                acti.Date = activite.Date;
                acti.Duree = activite.Duree;
                acti.TypeActivite = typeActi;

               // unitOfWork.ActiviteRepository.UpdateActivite(acti);
               // unitOfWork.Save();



                //db.Entry(activite).State = EntityState.Modified;
              //  db.SaveChanges();
                unitOfWork.ActiviteRepository.UpdateActivite(acti);
                unitOfWork.Save();

                return RedirectToAction("Index");
            }

            string[] tabIndexes2 = collection["UtilActivite"].ToString().Split(',');
            ICollection<Utilisateur> list2 = new List<Utilisateur>();
            for (int i = 0; i < tabIndexes2.Length; i++)
            {
                int indexReally = int.Parse(tabIndexes2[i]);
                list2.Add(unitOfWork.UtilisateurRepository.GetByID(indexReally));
            }
            activite.Utilisateurs = list2;

            ICollection<int> indexes2 = new List<int>();

            foreach (var item in activite.Utilisateurs)
            {
                indexes2.Add(item.PersonneId);
            }


            ViewBag.UtilActivite = new MultiSelectList(unitOfWork.UtilisateurRepository.ObtenirUtilisateurs(), "PersonneId", "NomPrenom", indexes2);
            ViewBag.TypeActivite = new SelectList(unitOfWork.TypeActiviteRepository.Get(), "TypeActiviteID", "NomActivite", activite.TypeActivite.TypeActiviteId);

            return View(activite);
        }

        // GET: Activites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Activite activite = db.Activite.Find(id);
            Activite activite = unitOfWork.ActiviteRepository.GetByID(id);
            if (activite == null)
            {
                return HttpNotFound();
            }
            return View(activite);
        }

        // POST: Activites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           // Activite activite = db.Activite.Find(id);
            //db.Activite.Remove(activite);
           // db.SaveChanges();
            Activite activite = unitOfWork.ActiviteRepository.GetByID(id);
            unitOfWork.ActiviteRepository.DeleteActivite(activite);
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
