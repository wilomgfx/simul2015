﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        public string Nom { get; set; }

        public virtual ICollection<CentreDeSki> CentreDeSkis { get; set; }
    }
}