//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Ticaret.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_SIPARISKALEMI
    {
        public int ID { get; set; }
        public Nullable<int> SIPARISID { get; set; }
        public Nullable<int> URUN { get; set; }
        public Nullable<int> ADET { get; set; }
        public Nullable<int> TUTAR { get; set; }
    
        public virtual TBL_SIPARIS TBL_SIPARIS { get; set; }
        public virtual TBL_URUN TBL_URUN { get; set; }
    }
}