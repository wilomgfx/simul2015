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
    public class EmployesController : Controller
    {
        //private Lab10Context db = new Lab10Context();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Employes
        public ActionResult Index()
        {
           // return View(db.Employes.ToList());
            return View(unitOfWork.EmployeRepository.Get().ToList());
        }

        // GET: Employes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Employe employe = db.Employes.Find(id);
            Employe employe = unitOfWork.EmployeRepository.GetByID(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: Employes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonneId,DateRecrutement,NomPrenom,DateNaissance,Commentaire")] Employe employe)
        {
            if (ModelState.IsValid)
            {
              //  db.Employes.Add(employe);
               // db.SaveChanges();
                unitOfWork.EmployeRepository.InsertEmploye(employe);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(employe);
        }

        // GET: Employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Employe employe = db.Employes.Find(id);
            Employe employe = unitOfWork.EmployeRepository.GetByID(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonneId,DateRecrutement,NomPrenom,DateNaissance,Commentaire")] Employe employe)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(employe).State = EntityState.Modified;
               // db.SaveChanges();
                unitOfWork.EmployeRepository.UpdateEmploye(employe);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(employe);
        }

        // GET: Employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Employe employe = db.Employes.Find(id);
            Employe employe = unitOfWork.EmployeRepository.GetByID(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           // Employe employe = db.Employes.Find(id);
           // db.Employes.Remove(employe);
           // db.SaveChanges();
            Employe employe = unitOfWork.EmployeRepository.GetByID(id);
            unitOfWork.EmployeRepository.DeleteEmploye(employe);
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
