using proje1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje1.Models
{
    public class Bildirim
    {
        Veriİcerigi db = new Veriİcerigi();
        public List<Order>SiparisBekleyenListe()
        {
            return db.Orders.Where(i => i.OrderState == EnumOrderState.Bekleniyor).ToList();
        }
    }
}