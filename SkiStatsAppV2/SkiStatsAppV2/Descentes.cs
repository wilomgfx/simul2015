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
    
    public partial class Descentes
    {
        public int DescenteId { get; set; }
        public int SortieId { get; set; }
    
        public virtual Sorties Sorties { get; set; }
    }
}
