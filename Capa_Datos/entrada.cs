//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capa_Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class entrada
    {
        public int id { get; set; }
        public int prod { get; set; }
        public int cantidad { get; set; }
        public double precio_n { get; set; }
        public double precio_total { get; set; }
        public System.DateTime fecha { get; set; }
        public int cliente { get; set; }
    
        public virtual cliente cliente1 { get; set; }
        public virtual product product { get; set; }
    }
}
