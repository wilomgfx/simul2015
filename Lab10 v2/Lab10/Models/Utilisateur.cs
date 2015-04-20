using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Lab10.Models
{
    public partial class Utilisateur : Personne
    {
        [DataType(DataType.Date)]
        public DateTime DateInscription { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDebutContrat { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFinContrat { get; set; }
        public int Poids { get; set; }
        //proprietés de navigation

        public virtual ICollection<Activite> Activites { get; set; }


    }

}