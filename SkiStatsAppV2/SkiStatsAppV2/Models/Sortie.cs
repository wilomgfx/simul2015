using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.Models
{
    public class Sortie
    {
        [Key]
        public int SortieId { get; set; }

        [ForeignKey("Saison")]
        public int SaisonId { get; set; }
        public virtual Saison Saison { get; set; }

        [ForeignKey("CentreDeSki")]
        public int CentreDeSkiId { get; set; }
        public virtual CentreDeSki CentreDeSki { get; set; }

        public virtual ICollection<Descente> Descentes { get; set; }
    }
}