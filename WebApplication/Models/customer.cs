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
    
    public partial class customer
    {
        public customer()
        {
            this.order = new HashSet<order>();
        }
    
        public int idCustomer { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public System.DateTime birthdate { get; set; }
        public string address { get; set; }
        public int idCity { get; set; }
        public int idCredentials { get; set; }
    
        public virtual cities cities { get; set; }
        public virtual credentials credentials { get; set; }
        public virtual ICollection<order> order { get; set; }
    }
}