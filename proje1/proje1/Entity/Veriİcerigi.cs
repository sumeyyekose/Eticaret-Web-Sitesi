using proje1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace proje1.Entity
{
    public class Veriİcerigi : DbContext
    {
        public  Veriİcerigi():base("dataConnection")
        {
            Database.SetInitializer(new VeriBaslatici());
        }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }


    }
}