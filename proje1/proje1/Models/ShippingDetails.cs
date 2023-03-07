﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje1.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lütfen Adres Tanımını Giriniz.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen Adres Giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen Sehir Giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen Semt Giriniz.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen Mahalle Giriniz.")]
        public string Mahalle { get; set; }

        [Required(ErrorMessage = "Lütfen Posta Kodu Giriniz.")]
        public string PostaKodu { get; set; }
    }
}