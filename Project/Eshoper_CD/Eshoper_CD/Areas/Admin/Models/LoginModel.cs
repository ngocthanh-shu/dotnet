using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eshoper_CD.Areas.Admin
{
    public class LoginModel
    {
        [Required]
        public string username {  get; set; }
        public string password {  get; set; }
        public bool rememberme {  get; set; }
    }
}