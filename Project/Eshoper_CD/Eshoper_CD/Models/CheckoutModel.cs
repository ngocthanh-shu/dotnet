using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Models
{
    public class CheckoutModel
    {
        public string email {  get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public string message { get; set; }
    }
}