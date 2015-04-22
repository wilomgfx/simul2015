using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private SkiStatsAppV2ContextDbContext context = new SkiStatsAppV2ContextDbContext();

        private CentreDeSkiRepository centreDeSkiRepository;

        private DescenteRepository descenteRepository;

        private RegionRepository regionRepository;

        private SaisonRepository saisonRepository;

        private SortieRepository sortieRepository;



        public CentreDeSkiRepository CentreDeSkiRepository
        {
            get
            {
                if (this.centreDeSkiRepository == null)
                {
                    this.centreDeSkiRepository = new CentreDeSkiRepository(context);
                }
                return centreDeSkiRepository;
            }
        }

        public DescenteRepository DescenteRepository
        {
            get
            {
                if (this.descenteRepository == null)
                {
                    this.descenteRepository = new DescenteRepository(context);
                }
                return descenteRepository;
            }
        }

        public RegionRepository RegionRepository
        {
            get
            {
                if (this.regionRepository == null)
                {
                    this.regionRepository = new RegionRepository(context);
                }
                return regionRepository;
            }
        }

        public SaisonRepository SaisonRepository
        {
            get
            {
                if (this.saisonRepository == null)
                {
                    this.saisonRepository = new SaisonRepository(context);
                }
                return saisonRepository;
            }
        }

        public SortieRepository SortieRepository
        {
            get
            {
                if (this.sortieRepository == null)
                {
                    this.sortieRepository = new SortieRepository(context);
                }
                return sortieRepository;
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