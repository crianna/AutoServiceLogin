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
    
    public partial class Model
    {
        public Model()
        {
            this.Vehiculs = new HashSet<Vehicul>();
        }
    
        public int ModelID { get; set; }
        public string Nume { get; set; }
        public int ProducatorID { get; set; }
    
        public virtual Producator Producator { get; set; }
        public virtual ICollection<Vehicul> Vehiculs { get; set; }
    }
}
