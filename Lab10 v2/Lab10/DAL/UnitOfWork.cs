using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private Lab10Context context = new Lab10Context();

        private EmployeRepository employeRepository;
        private ActiviteRepository activiteRepository;
        private UtilisateurRepository utilisateurRepository;
        private TypeActiviteRepository typeActiviteRepository;

        public ActiviteRepository ActiviteRepository
        {
            get
            {
                if (this.activiteRepository == null)
                {
                    this.activiteRepository = new ActiviteRepository(context);
                }
                return activiteRepository;
            }
        }

        public EmployeRepository EmployeRepository
        {
            get
            {
                if (this.employeRepository == null)
                {
                    this.employeRepository = new EmployeRepository(context);
                }
                return employeRepository;
            }
        }
        public UtilisateurRepository UtilisateurRepository
        {
            get
            {
                if (this.utilisateurRepository == null)
                {
                    this.utilisateurRepository = new UtilisateurRepository(context);
                }
                return utilisateurRepository;
            }
        }
        public TypeActiviteRepository TypeActiviteRepository
        {
            get
            {
                if (this.typeActiviteRepository == null)
                {
                    this.typeActiviteRepository = new TypeActiviteRepository(context);
                }
                return typeActiviteRepository;
            }
        }



        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}