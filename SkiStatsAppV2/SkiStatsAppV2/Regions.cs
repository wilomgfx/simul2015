//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SkiStatsAppV2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Regions
    {
        public Regions()
        {
            this.CentreDeSkis = new HashSet<CentreDeSkis>();
        }
    
        public int RegionId { get; set; }
        public string Nom { get; set; }
    
        public virtual ICollection<CentreDeSkis> CentreDeSkis { get; set; }
    }
}
