using SkiStatsAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.DAL
{
    public class SaisonRepository : GenericRepository<Saison>
    {
        public SaisonRepository(SkiStatsAppV2ContextDbContext context) : base(context) { }

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
    }
}