using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormCommerce.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("E-Posta")]
        [EmailAddress(ErrorMessage = "E-posta adresinizi düzgün giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifre ve Şifre Tekrarı uyuşmuyor")]
        public string RePassword { get; set; }
    }
}