using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Areas.Admin.Models
{
    public class CreateAccountModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
        public string email { get; set; }
        public string lname { get; set; }
        public string fname { get; set; }
    }
}