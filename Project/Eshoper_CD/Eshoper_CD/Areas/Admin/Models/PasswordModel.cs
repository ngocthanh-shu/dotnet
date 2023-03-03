using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Areas.Admin.Models
{
    public class PasswordModel
    {
        [Required]
        public string username { get; set; }
        public string password { get; set; }
        public string newpassword { get; set; }
        public string repeatpassword { get; set; }
    }
}