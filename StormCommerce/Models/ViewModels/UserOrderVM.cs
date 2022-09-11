using StormCommerce.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StormCommerce.Models.ViewModels
{
    public class UserOrderVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderState OrderState { get; set; }
    }
}