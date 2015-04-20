using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Lab10.Models
{
    public class Employe : Personne
    {
        [DataType(DataType.Date)]
        public DateTime DateRecrutement { get; set; }
        
        public virtual ICollection<TypeActivite>  TypeActivites{ get; set; }     

    }
}