using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.Models
{
    public class Saison
    {
        public int SaisonId { get; set; }

        public DateTime Annee { get; set; }

        public virtual ICollection<Sortie> Sorties { get; set; }
    }
}