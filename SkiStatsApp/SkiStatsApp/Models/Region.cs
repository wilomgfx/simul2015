using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkiStatsApp.Models;

namespace SkiStatsApp.Models
{
    public class Region
    {
        private int RegionId { get; set; }

        private string Nom { get; set; }

        public virtual ICollection<CentreDeSki> CentreDeSki { get; set; }
    }
}