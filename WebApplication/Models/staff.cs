//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class staff
    {
        public staff()
        {
            this.availibility = new HashSet<availibility>();
            this.delivery = new HashSet<delivery>();
        }
    
        public int idStaff { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<availibility> availibility { get; set; }
        public virtual ICollection<delivery> delivery { get; set; }
    }
}
