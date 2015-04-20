using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.DAL
{
    public class UtilisateurRepository : GenericRepository<Utilisateur>
    {
        public UtilisateurRepository(Lab10Context context) : base(context) { }

        public IEnumerable<Utilisateur> ObtenirUtilisateurs()
        {
            return Get();
        }
        public Utilisateur ObtenirUtilisateurParID(int? id)
        {
            return GetByID(id);
        }

        public void InsertUtilisateur(Utilisateur Utilisateur) { Insert(Utilisateur); }
        public void DeleteUtilisateur(Utilisateur Utilisateur) { Delete(Utilisateur); }
        public void UpdateUtilisateur(Utilisateur Utilisateur) { Update(Utilisateur); }
    }
}