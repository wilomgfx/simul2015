﻿using SkiStatsAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.DAL
{
    public class SaisonRepository : GenericRepository<Saison>
    {
        public SaisonRepository(SkiStatsAppV2ContextDbContext context) : base(context) { }

        public Saison ObtenirSaisonComplete(int? id)
        {
            return Get(filter: a => a.SaisonId == id, includeProperties: "Sorties").First();
        }       

        public IEnumerable<Saison> GetSaisons() { return Get(); }

        public Saison GetSaisonByID(int? id) { return GetByID(id); }

        public void InsertSaison(Saison Saison) { Insert(Saison); }

        public void UpdateSaison(Saison Saison) { Update(Saison); }

        public void DeleteSaison(Saison Saison) { Delete(Saison); }

        public int ObtenirNombreDeJoursSkier(Saison saison)
        {
            int nombreDeJours = 0;
            foreach (Sortie sorties in saison.Sorties)
            {
                nombreDeJours++;
            }
            return nombreDeJours;
        }
        public int ObtenirNombreDeDifferenteRegionsSkier(Saison saison)
        {
            int nombreDeDifferenteRegion = 0;
            List<Region> lstRegion = new List<Region>();

            foreach (Region region in saison.Sorties.Select(r => r.CentreDeSki.Region))
            {
                if (!lstRegion.Contains(region))
                {
                    lstRegion.Add(region);
                    nombreDeDifferenteRegion++;
                }
            }
            return nombreDeDifferenteRegion;
        }
        public int ObtenirNombreDeNouvelleRegionsSkier(Saison saison)
        {
            int nombreDeDifferenteRegion = 0;
            List<Region> lstRegionDejaSkier = new List<Region>();

            foreach (Region region in saison.Sorties.Select(r => r.CentreDeSki.Region))
            {

                lstRegionDejaSkier.Add(region);
                //if (!lstRegionDejaSkier.Contains(regions))
                //{
                //    lstRegionDejaSkier.Add(regions);
                //    nombreDeDifferenteRegion++;
                //}
            }
            foreach (Region region in lstRegionDejaSkier)
            {
                if (saison.Sorties.Where(r => r.CentreDeSki.Region == region).Count() != 0)
                {
                    nombreDeDifferenteRegion++;
                }
            }
            return nombreDeDifferenteRegion;
        }
        public int ObtenirNombreDePiedsVerticaux(Saison saison)
        {
            int nombreDePiedsVerticaux = 0;

            foreach (Descente descente in saison.Sorties.Select(r => r.Descentes))
            {
                nombreDePiedsVerticaux += descente.PiedVerticauxParcourus;
            }

            return nombreDePiedsVerticaux;
        }

        public decimal ObtenirAverageRunsPerDay(int? id)
        {
            Saison saison = ObtenirSaisonComplete(id);

            IEnumerable<Sortie> lstSorties = saison.Sorties;

            int nbrSorties = lstSorties.Count();

            int nbrDescente = 0;

            foreach (Sortie sort in lstSorties)
            {
                foreach (Descente desc in sort.Descentes)
                {
                    nbrDescente++;
                }
            }

            decimal average = (decimal)nbrDescente / (decimal)nbrSorties;

            return average;
        }

        public decimal ObtenirAverageFeetPerDay(int? id)
        {
            Saison saison = ObtenirSaisonComplete(id);

            IEnumerable<Sortie> lstSorties = saison.Sorties;

            int nbrDays = lstSorties.Count();

            int totalFeet = 0;

            foreach (Sortie sort in lstSorties)
            {
                foreach (Descente desc in sort.Descentes)
                {
                    totalFeet += desc.PiedVerticauxParcourus;
                }
            }



            decimal average = (decimal)totalFeet / (decimal)nbrDays;

            return average;
        }

        public decimal ObtenirAverageFeetPerRun(int? id)
        {
            Saison saison = ObtenirSaisonComplete(id);

            IEnumerable<Sortie> lstSorties = saison.Sorties;

            int nbrDescente = 0;
            int totalFeet = 0;

            foreach (Sortie sort in lstSorties)
            {
                foreach (Descente desc in sort.Descentes)
                {
                    nbrDescente++;
                    totalFeet += desc.PiedVerticauxParcourus;
                }
            }



            decimal average = (decimal)totalFeet / (decimal)nbrDescente;

            return average;
        }

        public string ObtenirPremiereJourneeDeSki(int? id)
        {
            Saison saison = ObtenirSaisonComplete(id);

            IEnumerable<Sortie> lstSorties = saison.Sorties;

            DateTime minDate = DateTime.Now;
            Sortie premiere = null;

            foreach (Sortie sort in lstSorties)
            {
                if (sort.Date < minDate)
                {
                    premiere = sort;
                    minDate = sort.Date;
                }
            }

            if (premiere == null)
                return "";

            return minDate.DayOfWeek.ToString();
        }

        public string ObtenirPremiereDateDeSki(int? id)
        {
            Saison saison = ObtenirSaisonComplete(id);

            IEnumerable<Sortie> lstSorties = saison.Sorties;

            DateTime minDate = DateTime.Now;
            Sortie premiere = null;

            foreach (Sortie sort in lstSorties)
            {
                if (sort.Date < minDate)
                {
                    premiere = sort;
                    minDate = sort.Date;
                }
            }

            if (premiere == null)
                return null;

            return minDate.Month.ToString("mmm") + " " + minDate.Day.ToString();
        }

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