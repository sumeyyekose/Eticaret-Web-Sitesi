using proje1.Entity;
using proje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje1.Controllers
{
    public class HomeController : Controller
    {

        Veriİcerigi db = new Veriİcerigi();


        public ActionResult Index()
        {
            var urun = db.Uruns.Where(i => i.Homdami && i.Onaylimi).Select(i => new UrunModel()
            {
                Id = i.Id,
                Adi = i.Adi,
                Aciklama = i.Aciklama.Length > 25 ? i.Aciklama.Substring(0, 20) + "..." : i.Aciklama,
                Fiyat = i.Fiyat,
                Stok = i.Stok,
                Resim = i.Resim,
                KategoriId = i.KategoriId
            }).ToList();

            return View(urun);
        }


        public PartialViewResult Slider()
        {
            return PartialView(db.Uruns.Where(x => x.Slider && x.Onaylimi).ToList());

        }





        public PartialViewResult OnecikanUrunler()
        {
            return PartialView(db.Uruns.Where(x=>x.Onecikanmi && x.Onaylimi).Take(2).ToList());

        }



        public ActionResult UrunListesi(int id)
        {
            return View(db.Uruns.Where(i => i.KategoriId == id).ToList());

        }




        public ActionResult UrunDetay(int id)
        {
            return View(db.Uruns.Where(i=>i.Id==id).FirstOrDefault());
        }


        public ActionResult Ara(string b)
        {
            var a = db.Uruns.Where(x => x.Onaylimi == true);
            if (!string.IsNullOrEmpty(b))
            {
                a = a.Where(x => x.Adi.Contains(b) || x.Aciklama.Contains(b));
            }
            return View(a.ToList());

        }



        public ActionResult Urun()
        {

            var urun = db.Uruns.Where(i =>i.Onaylimi).Select(i => new UrunModel()
            {
                Id = i.Id,
                Adi = i.Adi,
                Aciklama = i.Aciklama.Length > 25 ? i.Aciklama.Substring(0, 20) + "..." : i.Aciklama,
                Fiyat = i.Fiyat,
                Stok = i.Stok,
                Resim = i.Resim,
                KategoriId = i.KategoriId
            }).ToList();

            return View(urun);



        }



    }
}