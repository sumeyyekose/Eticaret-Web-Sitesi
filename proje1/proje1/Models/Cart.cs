using proje1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje1.Models
{
    public class Cart
    {
        private List<CartLine> cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return cartLines; }

        }
        public void AddProduct(Urun urun,int adet)
        {
            var line = cartLines.FirstOrDefault(i => i.Urun.Id == urun.Id);
            if (line==null)
            {
                cartLines.Add(new CartLine() { Urun = urun, Adet = adet });
            }
            else
            {
                line.Adet += adet;
            }

        }

        public void DeleteProduct(Urun urun)
        {
            cartLines.RemoveAll(i => i.Urun.Id == urun.Id);
        }

        public double Total()
        {
            return cartLines.Sum(i => i.Urun.Fiyat * i.Adet);

        }

        public void Clear()
        {
            cartLines.Clear();

        }


    }


    public class CartLine
    {
        public Urun Urun { get; set; }
        public int Adet { get; set; }

    }

}