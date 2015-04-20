using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab10.Models
{
    public class Activite
    {
        public int ActiviteId { get; set; }
        public int Duree { get; set; }
        public DateTime Date { get; set; }
        //proprietés de navigation

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
        public virtual TypeActivite TypeActivite { get; set; }

    }

}