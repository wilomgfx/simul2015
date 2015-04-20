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
    public class TypeActivitesController : Controller
    {
      //  private Lab10Context db = new Lab10Context();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: TypeActivites
        public ActionResult Index()
        {
            //return View(db.TypeActivites.ToList());
            return View(unitOfWork.TypeActiviteRepository.Get().ToList());
        }

        // GET: TypeActivites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          //  TypeActivite typeActivite = db.TypeActivites.Find(id);
            TypeActivite typeActivite = unitOfWork.TypeActiviteRepository.GetByID(id);
            if (typeActivite == null)
            {
                return HttpNotFound();
            }
            return View(typeActivite);
        }

        // GET: TypeActivites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeActivites/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeActiviteId,NomActivite,CaloriePerduHeure")] TypeActivite typeActivite)
        {
            if (ModelState.IsValid)
            {
               // db.TypeActivites.Add(typeActivite);
                //db.SaveChanges();
                unitOfWork.TypeActiviteRepository.InsertTypeActivite(typeActivite);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(typeActivite);
        }

        // GET: TypeActivites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TypeActivite typeActivite = db.TypeActivites.Find(id);
            TypeActivite typeActivite = unitOfWork.TypeActiviteRepository.GetByID(id);
            if (typeActivite == null)
            {
                return HttpNotFound();
            }
            return View(typeActivite);
        }

        // POST: TypeActivites/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeActiviteId,NomActivite,CaloriePerduHeure")] TypeActivite typeActivite)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(typeActivite).State = EntityState.Modified;
                //db.SaveChanges();
                unitOfWork.TypeActiviteRepository.UpdateTypeActivite(typeActivite);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(typeActivite);
        }

        // GET: TypeActivites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TypeActivite typeActivite = db.TypeActivites.Find(id);
            TypeActivite typeActivite = unitOfWork.TypeActiviteRepository.GetByID(id);
            if (typeActivite == null)
            {
                return HttpNotFound();
            }
            return View(typeActivite);
        }

        // POST: TypeActivites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TypeActivite typeActivite = db.TypeActivites.Find(id);
            // db.TypeActivites.Remove(typeActivite);
            //db.SaveChanges();
            TypeActivite typeActivite = unitOfWork.TypeActiviteRepository.GetByID(id);
            unitOfWork.TypeActiviteRepository.DeleteTypeActivite(typeActivite);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
