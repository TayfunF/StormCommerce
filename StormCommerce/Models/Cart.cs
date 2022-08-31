using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StormCommerce.Models
{
    public class Cart
    {
        private List<CartLine> _CartLines = new List<CartLine>();
        public List<CartLine> CartLines { get { return _CartLines; } }

        public void AddProduct(Product product, int quantity)
        {
            var Line = _CartLines.Where(x => x.Product.Id == product.Id).FirstOrDefault();

            if (Line == null)
            {
                _CartLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                Line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _CartLines.RemoveAll(x => x.Product.Id == product.Id);
        }
        public double TotalProduct()
        {
            return _CartLines.Sum(x => x.Product.Price * x.Quantity);
        }
        public void Clear()
        {
            _CartLines.Clear();
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}