using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkiStatsAppV2.Models;
using System.ComponentModel;

namespace SkiStatsAppV2.ViewModels
{
    public class StatsSaisonGenerale
    {
        public Saison Saison { get; set; }

        [DisplayName("Nombres de jours skiés")]
        public int nbrDaysSkiing { get; set; }
        [DisplayName("Nombre de centre de ski différents")]
        public int nbrDifferentSkiAreas { get; set; }
        [DisplayName("Nombre de nouveaux centres de ski")]
        public int nbrNewSkiAreas { get; set; }
        [DisplayName("Nombre de descentes")]
        public int nbrOfRuns { get; set; }
        [DisplayName("Pieds verticaux parcourus")]
        public int totalVerticalFeet { get; set; }
        [DisplayName("Moyenne de descentes par jour")]
        public decimal avgRunsPerDay { get; set; }
        [DisplayName("Moyenne de pieds verticaux parcourus par jour")]
        public decimal avgFeetPerDay { get; set; }
        [DisplayName("Moyenne de pieds verticaux parcourus par descente")]
        public decimal avgFeetPerRun { get; set; }
        [DisplayName("Premier jour de ski")]
        public string firstDayOfSkiing { get; set; }
        [DisplayName("Date du premier jour de ski")]
        public string firstDateOfSkiing { get; set; }
        [DisplayName("Premier centre de ski")]
        public CentreDeSki firstSkiArea { get; set; }
        [DisplayName("Dernier jour de ski")]
        public string lastDayOfSkiing { get; set; }
        [DisplayName("Derniere date de ski")]
        public string lastDateOfSkiing { get; set; }
        [DisplayName("Dernier centre de ski")]
        public CentreDeSki lastSkiArea { get; set; }
        [DisplayName("Nombre de jours dans cette saison")]
        public double lengthOfSeason { get; set; }
        [DisplayName("Moyenne de jours entre les sorties")]
        public double avgElapsedDays { get; set; }
    }
}