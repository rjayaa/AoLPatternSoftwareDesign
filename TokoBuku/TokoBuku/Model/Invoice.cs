//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TokoBuku.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public string InvoiceID { get; set; }
        public string TransactionID { get; set; }
        public int Amount { get; set; }
        public System.DateTime IssuedDate { get; set; }
    
        public virtual Transaction Transaction { get; set; }
    }
}
