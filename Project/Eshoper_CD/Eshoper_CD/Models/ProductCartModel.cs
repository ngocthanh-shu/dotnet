using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Models
{
    public class ProductCartModel
    {
        public int cartId { get; set; }
        public int productId { get; set; }
        public string productImg { get; set; }
        public string productName { get; set; }
        public double? productPrice { get; set; }
        public int? cartQuanity { get; set; }
        public double? total {  get; set; }
    }
}