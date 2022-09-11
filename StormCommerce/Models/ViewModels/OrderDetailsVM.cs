using StormCommerce.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StormCommerce.Models.ViewModels
{
    public class OrderDetailsVM
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderState OrderState { get; set; }

        public string Username { get; set; }
        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Distinct { get; set; }
        public string PostalCode { get; set; }



        //Nav Prop
        public virtual List<OrderLineVM> OrderLines { get; set; }
    }

    public class OrderLineVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}