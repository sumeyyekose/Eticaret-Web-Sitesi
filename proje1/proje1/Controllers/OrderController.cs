using proje1.Entity;
using proje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje1.Controllers
{
    public class OrderController : Controller
    {

        Veriİcerigi db = new Veriİcerigi();
        [Authorize(Roles = "admin")]
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count=i.OrderLines.Count

            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }

        public ActionResult Details(int id)
        {

            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName=i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdresBasligi = i.AdresBasligi,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    UrunId = x.UrunId,
                    Resim = x.Urun.Resim,
                    UrunName = x.Urun.Adi,
                    Adet = x.Adet,
                    Fiyat = x.Fiyat
                }).ToList()

            }).FirstOrDefault();
            return View(entity);

        }
        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order!=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["Mesaj"] = "Bilgileriniz Kaydedildi.";
                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
        public ActionResult BeklenenSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Bekleniyor).ToList();
            return View(orders);

        }


        public ActionResult KargolananSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Kargolandı).ToList();
            return View(orders);

        }


        public ActionResult TamamlananSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Tamamlandı).ToList();
            return View(orders);

        }

        public ActionResult PaketlenenSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Paketlendi).ToList();
            return View(orders);

        }


    }
}