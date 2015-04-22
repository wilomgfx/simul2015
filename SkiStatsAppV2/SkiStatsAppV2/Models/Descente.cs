using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace SkiStatsAppV2.Models
{
    public class Descente
    {
        public int DescenteId { get; set; }

        [ForeignKey("Sortie")]
        public int SortieId { get; set; }
        public virtual Sortie Sortie { get; set; }
    }
}