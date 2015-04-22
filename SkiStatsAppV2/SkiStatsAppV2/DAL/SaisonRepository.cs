using SkiStatsAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.DAL
{
    public class SaisonRepository : GenericRepository<Saison>
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public SaisonRepository(SkiStatsAppV2ContextDbContext context) : base(context) { }

        public IEnumerable<Saison> GetSaisons() { return Get(); }

        public Saison GetSaisonByID(int? id) { return GetByID(id); }

        public void InsertSaison(Saison Saison) { Insert(Saison); }

        public void UpdateSaison(Saison Saison) { Update(Saison); }

        public void DeleteSaison(Saison Saison) { Delete(Saison); }

     

        public CentreDeSki FirstSkiArea(Saison Saison)
        {
            // retourne la premiere sortie de la saison donnée
            Sortie premiereSortieSaison = unitOfWork.SortieRepository.ObtenirSortie().Where(d => d.Saison == Saison).Where(t => t.Date == Saison.Annee).First();

            //retourne le premiere centre de ski de la saison donnée
            return premiereSortieSaison.CentreDeSki;

            
        }

        public string LastDaySkiingDD(Saison Saison)
        {
            // sort la derniere journee de ski de la saison donnée
            Sortie derniereSortieDeLaSaison = unitOfWork.SortieRepository.ObtenirSortie().Where(d => d.Saison == Saison).Where(t => t.Date == Saison.DateFin).First();

            // retourne le jour de la semaine en string de cette derniere date 
            return derniereSortieDeLaSaison.Date.DayOfWeek.ToString();

        }

        public string LastDaySkiingMMdd(Saison Saison)
        {
            // sort la derniere journee de ski de la saison donnée
            Sortie derniereSortieDeLaSaison = unitOfWork.SortieRepository.ObtenirSortie().Where(d => d.Saison == Saison).Where(t => t.Date == Saison.DateFin).First();

            // retourne le jour de la semaine en string de cette derniere date 
            string date = derniereSortieDeLaSaison.Date.Month.ToString("mmm") + " " + derniereSortieDeLaSaison.Date.Day.ToString("dd");

            return date;

        }

        public CentreDeSki LastSkiArea(Saison Saison)
        {
            // retourne la derniere sortie de la saison donnée
            Sortie derniereSortieSaison = unitOfWork.SortieRepository.ObtenirSortie().Where(d => d.Saison == Saison).Where(t => t.Date == Saison.DateFin).First();

            //retourne le derniere centre de ski de la saison donnée
            return derniereSortieSaison.CentreDeSki;


        }
        
    }
}