using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StormCommerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        public double Price { get; set; }

        [DisplayName("Stok")]
        public int Stock { get; set; }

        [DisplayName("Resim")]
        public string Image { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}