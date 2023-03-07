using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje1.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage ="Geçersiz Eposta.")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Sifre")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Sifre Tekrar")]
        [Compare("Password", ErrorMessage ="Şifreler aynı değil.")]
        public string Repassword { get; set; }
    }
}