using SkiStatsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace SkiStatsApp.DAL
{

    public class SkiStatsAppContext : DbContext
    {
        public SkiStatsAppContext() : base() { }

        public DbSet<CentreDeSki> CentreDeSkis { get; set; }
        public DbSet<Descente> Descentes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Saison> Saisons { get; set; }
        public DbSet<Sortie> Sorties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
    
}