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
    
    public partial class Sorties
    {
        public Sorties()
        {
            this.Descentes = new HashSet<Descentes>();
        }
    
        public int SortieId { get; set; }
        public int SaisonId { get; set; }
        public int CentreDeSkiId { get; set; }
    
        public virtual CentreDeSkis CentreDeSkis { get; set; }
        public virtual ICollection<Descentes> Descentes { get; set; }
        public virtual Saisons Saisons { get; set; }
    }
}
