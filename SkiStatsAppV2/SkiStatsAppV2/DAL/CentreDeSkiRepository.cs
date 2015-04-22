using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkiStatsAppV2.Models;

namespace SkiStatsAppV2.DAL
{

    public class CentreDeSkiRepository : GenericRepository<CentreDeSki>
    {
        public CentreDeSkiRepository(SkiStatsAppV2ContextDbContext context) : base(context) { }

        public IEnumerable<CentreDeSki> ObtenirCentreDeSki()
        {
            return Get();
        }
        public CentreDeSki ObtenirCentreDeSkiParID(int? id)
        {
            return GetByID(id);
        }

        public void InsertDescente(CentreDeSki CentreDeSki) { Insert(CentreDeSki); }
        public void DeleteDescente(CentreDeSki CentreDeSki) { Delete(CentreDeSki); }
        public void UpdateDescente(CentreDeSki CentreDeSki) { Update(CentreDeSki); }
    }
}