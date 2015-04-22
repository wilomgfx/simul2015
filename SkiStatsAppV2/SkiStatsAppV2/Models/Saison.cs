using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.Models
{
    public class Saison
    {
        [Key]
        public int SaisonId { get; set; }

        public DateTime Annee { get; set; }

        public DateTime DateFin { get; set; }


        public virtual ICollection<Sortie> Sorties { get; set; }
    }
}