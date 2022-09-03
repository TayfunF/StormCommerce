using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormCommerce.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen adres başlığı giriniz")]
        public string AddressTitle { get; set; }

        [Required(ErrorMessage = "Lütfen adres giriniz")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lütfen mahalle giriniz")]
        public string Distinct { get; set; }
        public string PostalCode { get; set; }
    }
}