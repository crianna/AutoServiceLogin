//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoServiceLogin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producator
    {
        public Producator()
        {
            this.AfiliereServiceProducators = new HashSet<AfiliereServiceProducator>();
            this.Models = new HashSet<Model>();
        }
    
        public int ProducatorID { get; set; }
        public string Nume { get; set; }
    
        public virtual ICollection<AfiliereServiceProducator> AfiliereServiceProducators { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
