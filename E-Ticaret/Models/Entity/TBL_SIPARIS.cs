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
    
    public partial class TBL_SIPARIS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_SIPARIS()
        {
            this.TBL_SIPARISKALEMI = new HashSet<TBL_SIPARISKALEMI>();
        }
    
        public int ID { get; set; }
        public Nullable<int> UYE { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public Nullable<int> TOPLAMTUTAR { get; set; }
        public Nullable<int> DURUM { get; set; }
        public Nullable<int> ADRES { get; set; }
    
        public virtual TBL_DURUM TBL_DURUM { get; set; }
        public virtual TBL_UYE TBL_UYE { get; set; }
        public virtual TBL_ADRES TBL_ADRES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SIPARISKALEMI> TBL_SIPARISKALEMI { get; set; }
    }
}
