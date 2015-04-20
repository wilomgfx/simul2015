using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  Lab10.DAL;
using Lab10.Models;
using System.ComponentModel.DataAnnotations;



namespace Lab10.ReglesDaffaire
{
    public class UtilisateurActiviteDateFinContrat
    {
        public static ValidationResult Validate(Lab10.Models.Utilisateur utilisateur)
        {


                if(utilisateur.DateFinContrat < DateTime.Now)
                {
                    return new ValidationResult("Le contrat de cet utilisateur est terminer");
                }
            

            return ValidationResult.Success;
        }
    }
}