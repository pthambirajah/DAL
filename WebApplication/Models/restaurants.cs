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
    
    public partial class restaurants
    {
        public restaurants()
        {
            this.dishes = new HashSet<dishes>();
        }
    
        public int idRestaurant { get; set; }
        public string merchant_name { get; set; }
        public string createdAt { get; set; }
        public int idCity { get; set; }
    
        public virtual cities cities { get; set; }
        public virtual ICollection<dishes> dishes { get; set; }
    }
}
