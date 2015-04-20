using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public abstract class Personne
    {
        [Key]
        public int PersonneId { get; set; }
        public string NomPrenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Commentaire { get; set; }


       
    }

}