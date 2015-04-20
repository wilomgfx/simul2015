using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.DAL
{
    public class EmployeRepository : GenericRepository<Employe>
    {
        public EmployeRepository(Lab10Context context) : base(context) { }

        public IEnumerable<Employe> ObtenirEmploye()
        {
            return Get();
        }
        public Employe ObtenirEmployeParID(int? id)
        {
            return GetByID(id);
        }
        public void InsertEmploye(Employe Employe) { Insert(Employe); }
        public void DeleteEmploye(Employe Employe) { Delete(Employe); }
        public void UpdateEmploye(Employe Employe) { Update(Employe); }
    }
}