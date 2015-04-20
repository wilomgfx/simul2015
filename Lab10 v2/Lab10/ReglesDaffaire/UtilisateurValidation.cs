using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.DAL;
using Lab10.Models;
using Lab10.ReglesDaffaire;
using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public partial class Utilisateur : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            yield return UtilisateurActiviteDateFinContrat.Validate(this);
            yield return NombreActiviteParJour.Validate(this);
        }
    }
}