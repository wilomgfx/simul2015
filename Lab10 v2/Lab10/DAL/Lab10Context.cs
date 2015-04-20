using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.Models;
using System.Data.Entity;


namespace Lab10.DAL
{
    public class Lab10Context : DbContext
    {
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<TypeActivite> TypeActivites { get; set; }
        public DbSet<Activite> Activite { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}