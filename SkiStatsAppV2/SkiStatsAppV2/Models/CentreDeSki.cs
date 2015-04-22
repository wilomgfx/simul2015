using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.Models
{
    public class CentreDeSki
    {
        [Key]
        public int CentreDeSkiId { get; set; }

        public string NomDuCentre { get; set; }

        [ForeignKey("Region")]
        public int RegionId {get;set;}

        public virtual Region Region { get ;set; }
    }
}