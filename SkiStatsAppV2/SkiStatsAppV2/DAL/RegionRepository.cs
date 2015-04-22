using SkiStatsAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.DAL
{
    public class RegionRepository : GenericRepository<Region>
    {
        public RegionRepository(SkiStatsAppV2ContextDbContext context) : base(context) { }

        public IEnumerable<Region> GetRegions() { return Get(); }

        public Region GetRegionByID(int? id) { return GetByID(id); }

        public void InsertRegion(Region Region) { Insert(Region); }

        public void UpdateRegion(Region Region) { Update(Region); }

        public void DeleteRegion(Region Region) { Delete(Region); }
    }
}