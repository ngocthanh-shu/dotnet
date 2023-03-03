using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Models
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "You Must Type Password")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You Must Type Password")]
        public string password { get; set; }
        public string passwordConfirm { get; set; }

        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
    }
}