using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Models
{
    public class ProfileModel
    {
        public string username { get; set; }
        public string password { get; set; }

        public string newPassword { get; set; }
        public string verify {  get; set; }

        public string fname { get; set; }
        public string lname { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }

        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string aboutme { get; set; }

    }
}