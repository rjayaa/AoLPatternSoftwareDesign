//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAB_RAMEN.Mode
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detail
    {
        public int id { get; set; }
        public int HeaderID { get; set; }
        public int RamenID { get; set; }
        public int Quantity { get; set; }
    
        public virtual Header Header { get; set; }
        public virtual Raman Raman { get; set; }
    }
}
