using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.DAL;
using Lab10.Models;
using System.ComponentModel.DataAnnotations;

namespace Lab10.ReglesDaffaire
{
    public class NombreActiviteParJour
    {
        public static ValidationResult Validate(Lab10.Models.Utilisateur utilisateur)
        {
            UnitOfWork uow = new UnitOfWork();

            //IEnumerable<Activite> listeActivite = uow.ActiviteRepository.ObtenirActivites();

            if(utilisateur.Activites != null)
            { 

            foreach(Activite activite in utilisateur.Activites)
            {
                int count = 0;
                foreach(Activite activites in utilisateur.Activites)
                {
                    if(activite.Date.Date == activites.Date.Date)
                    {
                        count++;
                    }
                    if(count >= 3)
                    {
                        return new ValidationResult("Cet utilisateur particippe déja à 3 activités");
                    }
                }
            }
        }
            return ValidationResult.Success;
        }
    }
}