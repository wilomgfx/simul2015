using SkiStatsAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiStatsAppV2.DAL
{
    public class DescenteRepository : GenericRepository<Descente>
    {
        public DescenteRepository(SkiStatsAppV2ContextDbContext context) : base(context) { }

        public IEnumerable<Descente> ObtenirDescente()
        {
            return Get();
        }
        public Descente ObtenirDescenteParID(int? id)
        {
            return GetByID(id);
        }

        public void InsertDescente(Descente Descente) { Insert(Descente); }
        public void DeleteDescente(Descente Descente) { Delete(Descente); }
        public void UpdateDescente(Descente Descente) { Update(Descente); }
    }
}