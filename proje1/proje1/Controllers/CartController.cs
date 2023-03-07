using proje1.Entity;
using proje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        Veriİcerigi db = new Veriİcerigi();




        public ActionResult Index()
        {
            return View(GetCart());
        }




        public ActionResult AddToCart(int Id)
        {
            var urun = db.Uruns.FirstOrDefault(i => i.Id == Id);
            if (urun!=null)
            {
                GetCart().AddProduct(urun, 1);
            }
            return RedirectToAction("Index");
            
        }





        public ActionResult RemoveFromCart(int Id)
        {
            var urun = db.Uruns.FirstOrDefault(i => i.Id == Id);
            if (urun != null)
            {
                GetCart().DeleteProduct(urun);
            }
            return RedirectToAction("Index");

        }







    
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }




        public PartialViewResult Summary()
        {
            return PartialView(GetCart());

        }





        public ActionResult Checkout()
        {
            return View(new ShippingDetails());

        }





        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count==0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde Ürün Bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
            
        }





        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniyor;
            order.UserName = User.Identity.Name;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();
            foreach (var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Adet = pr.Adet;
                orderline.Fiyat = pr.Adet * pr.Urun.Fiyat;
                orderline.UrunId = pr.Urun.Id;
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}