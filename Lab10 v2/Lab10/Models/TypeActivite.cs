using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab10.Models
{
    public class TypeActivite
    {
        public int TypeActiviteId { get; set; }
        public string NomActivite { get; set; }
        public int CaloriePerduHeure { get; set; }
        //proprietés de navigation

        public virtual ICollection<Activite> Activite { get; set; }

        //public int PersonneId { get; set; }
        public virtual Employe Employe { get; set; }
    }

}