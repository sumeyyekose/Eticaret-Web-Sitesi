using proje1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje1.Models
{
    public class State
    {
        Veriİcerigi db = new Veriİcerigi();
        public StateModelStyle GetModelState()
        {
            StateModelStyle models = new StateModelStyle();
            models.BeklenenSiparisler = db.Orders.Where(i => i.OrderState == EnumOrderState.Bekleniyor).ToList().Count();
            models.KargolananSiparisler = db.Orders.Where(i => i.OrderState == EnumOrderState.Kargolandı).ToList().Count();
            models.TamamlananSiparisler = db.Orders.Where(i => i.OrderState == EnumOrderState.Tamamlandı).ToList().Count();
            models.PaketlenenSiparisler = db.Orders.Where(i => i.OrderState == EnumOrderState.Paketlendi).ToList().Count();
            models.UrunSayisi = db.Uruns.Count();
            models.SiparisSayisi = db.Orders.Count();
            return models;
        }
    }

    public class StateModelStyle
    {
        public int UrunSayisi { get; set; }
        public int SiparisSayisi { get; set; }
        public int BeklenenSiparisler { get; set; }
        public int KargolananSiparisler { get; set; }
        public int TamamlananSiparisler { get; set; }
        public int PaketlenenSiparisler { get; set; }

    }


}