﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EticaretEntities1 : DbContext
    {
        public EticaretEntities1()
            : base("name=EticaretEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_DESTEK> TBL_DESTEK { get; set; }
        public virtual DbSet<TBL_DURUM> TBL_DURUM { get; set; }
        public virtual DbSet<TBL_KATEGORI> TBL_KATEGORI { get; set; }
        public virtual DbSet<TBL_MARKA> TBL_MARKA { get; set; }
        public virtual DbSet<TBL_PERSONEL> TBL_PERSONEL { get; set; }
        public virtual DbSet<TBL_SATIS> TBL_SATIS { get; set; }
        public virtual DbSet<TBL_SEPET> TBL_SEPET { get; set; }
        public virtual DbSet<TBL_SIPARIS> TBL_SIPARIS { get; set; }
        public virtual DbSet<TBL_SIPARISKALEMI> TBL_SIPARISKALEMI { get; set; }
        public virtual DbSet<TBL_URUN> TBL_URUN { get; set; }
        public virtual DbSet<TBL_UYE> TBL_UYE { get; set; }
        public virtual DbSet<TBL_YORUM> TBL_YORUM { get; set; }
        public virtual DbSet<TBL_OZELLIK> TBL_OZELLIK { get; set; }
        public virtual DbSet<TBL_URUNOZELLIK> TBL_URUNOZELLIK { get; set; }
        public virtual DbSet<TBL_FAVORI> TBL_FAVORI { get; set; }
        public virtual DbSet<TBL_ADRES> TBL_ADRES { get; set; }
    }
}