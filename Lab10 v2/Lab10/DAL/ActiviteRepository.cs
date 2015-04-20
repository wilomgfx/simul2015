using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab10.Models;

namespace Lab10.DAL
{
    public class ActiviteRepository : GenericRepository<Activite>
    {
        public ActiviteRepository(Lab10Context context) : base(context) { }

        public IEnumerable<Activite> ObtenirActivites()
        {
            return Get();
        }
        public Activite ObtenirActiviteParID(int? id)
        {
            return GetByID(id);
        }
       
        public void InsertActivite(Activite Activite) { Insert(Activite); }
        public void DeleteActivite(Activite Activite) { Delete(Activite); }
        public void UpdateActivite(Activite Activite) { Update(Activite); }
    }
}