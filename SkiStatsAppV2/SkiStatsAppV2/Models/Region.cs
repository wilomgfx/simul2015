using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.Models
{
    public class Region
    {
        private int RegionId { get; set; }

        private string Nom { get; set; }

        public virtual ICollection<CentreDeSki> CentreDeSkis { get; set; }
    }
}