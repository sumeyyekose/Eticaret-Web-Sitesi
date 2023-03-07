using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje1.Entity
{
    public class VeriBaslatici:DropCreateDatabaseIfModelChanges<Veriİcerigi>
    {
        protected override void Seed(Veriİcerigi context)
        {
            var kategoriler = new List<Kategori>()
            {
                new Kategori(){Adi="Kamera", Aciklama="Kamera Ürünleri"},
                new Kategori(){Adi="Bilgisayar", Aciklama="Bilgisayar Ürünleri"}
            };
            foreach (var item in kategoriler)
            {
                context.Kategoris.Add(item);

            }
            context.SaveChanges();

            var urunler = new List<Urun>()
            {
                new Urun(){Adi="Canon", Aciklama="Kamera",Fiyat=2000,Stok=50,Homdami=true,KategoriId=1,Resim="kamera.jpg",Onaylimi=true,Onecikanmi=false},
                new Urun(){Adi="Asus", Aciklama="Bilgisayar",Fiyat=5000,Stok=10,Homdami=true,KategoriId=2,Resim="pc.jpg",Onaylimi=true,Onecikanmi=true},
                new Urun(){Adi="Casper", Aciklama="Bilgisayar",Fiyat=3000,Stok=150,Homdami=true,KategoriId=2,Resim="pc2.jpg",Onaylimi=true,Onecikanmi=true},
            };
            foreach (var item in urunler)
            {
                context.Uruns.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }

    }
}