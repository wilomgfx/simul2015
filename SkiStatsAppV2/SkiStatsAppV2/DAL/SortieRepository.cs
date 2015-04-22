using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkiStatsAppV2.Models;


namespace SkiStatsAppV2.DAL
{
    public class SortieRepository : GenericRepository<Sortie>
    {
        public SortieRepository(SkiStatsAppV2ContextDbContext context) : base(context) { }

        public IEnumerable<Sortie> ObtenirSortie()
        {
            return Get();
        }
        public Sortie ObtenirSortieParID(int? id)
        {
            return GetByID(id);
        }

        public void InsertDescente(Sortie Sortie) { Insert(Sortie); }
        public void DeleteDescente(Sortie Sortie) { Delete(Sortie); }
        public void UpdateDescente(Sortie Sortie) { Update(Sortie); }
    }
}