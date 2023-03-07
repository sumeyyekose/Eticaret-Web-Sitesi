using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje1.Entity
{
    public class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }
        public int Stok { get; set; }
        public string Resim { get; set; }
        public bool Slider { get; set; }
        public bool Homdami { get; set; }
        public bool Onaylimi { get; set; }
        public bool Onecikanmi { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }


    }
}