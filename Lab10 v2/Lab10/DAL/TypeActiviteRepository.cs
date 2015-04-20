using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab10.Models;

namespace Lab10.DAL
{
    public class TypeActiviteRepository: GenericRepository<TypeActivite>
    {
        public TypeActiviteRepository(Lab10Context context) : base(context) { }

        public IEnumerable<TypeActivite> ObtenirTypeActivite()
        {
            return Get();
        }
        public TypeActivite ObtenirTypeActiviteParID(int? id)
        {
            return GetByID(id);
        }
        public void InsertTypeActivite(TypeActivite TypeActivite) { Insert(TypeActivite); }
        public void DeleteTypeActivite(TypeActivite TypeActivite) { Delete(TypeActivite); }
        public void UpdateTypeActivite(TypeActivite TypeActivite) { Update(TypeActivite); }
    }
}