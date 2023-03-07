using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje1.Models
{
    public class Giris
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Sifre")]
        public string Password { get; set; }
        public bool BeniHatirla { get; set; }

    }
}