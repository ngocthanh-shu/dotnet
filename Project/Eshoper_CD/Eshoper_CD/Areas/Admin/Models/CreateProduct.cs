using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Areas.Admin.Models
{
    public class CreateProduct
    {
        public IEnumerable<category> categories {  get; set; }
        public string name {  get; set; }
        public float price {  get; set; }
        public string img {  get; set; }
        public string description {  get; set; }
        public DateTime datebegin {  get; set; }
        public int quantity {  get; set; }
        public int categoryId {  get; set; }

        public HttpPostedFileBase image {  get; set; }
    }
}