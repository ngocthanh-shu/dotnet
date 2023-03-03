using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Models
{
    public class CartConfirmModel
    {
        public int cartId { get; set; }
        public double? totalProduct { get; set; }
        public int? ecoTax { get; set; }
        public int? shippingCost { get; set; }
        public double? total { get; set; }
    }
}