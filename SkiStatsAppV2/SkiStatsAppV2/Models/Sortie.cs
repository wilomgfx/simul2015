using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.Models
{
    public class Sortie
    {
        public int SortieId { get; set; }

        [ForeignKey("Saison")]
        public int SaisonId { get; set; }
        public virtual Saison Saison { get; set; }
    }
}