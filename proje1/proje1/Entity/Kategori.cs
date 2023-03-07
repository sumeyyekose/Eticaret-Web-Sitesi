using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje1.Entity
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public virtual List<Urun> Uruns{ get; set; }

    }
}