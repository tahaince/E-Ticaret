using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Ticaret.Models.Entity;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Models.Siniflar
{
    public class Class2
    {
        public IEnumerable<TBL_URUN> deger1 { get; set; }
        public IEnumerable<TBL_URUN> deger2 { get; set; }
        public IEnumerable<TBL_YORUM> deger3 { get; set; }
        public IEnumerable<TBL_URUNOZELLIK> deger4 { get; set; }
        public IEnumerable<TBL_KATEGORI> deger5 { get; set; }
        public IEnumerable<TBL_FAVORI> deger6 { get; set; }


    }
}