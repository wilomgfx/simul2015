using SkiStatsAppV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.DAL
{
    public class SkiStatsAppV2ContextDbContext :DbContext
    {
        public SkiStatsAppV2ContextDbContext() : base("SkiStatsAppV2ContextDbContext") { }

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