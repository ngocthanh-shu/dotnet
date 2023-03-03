using Eshoper_CD.Areas.Code;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Eshoper_CD.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {

            //var rs = new AccountModel().LoginAsAdminstrator(model.username, model.password);
            if(Membership.ValidateUser(model.username, model.password) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { username = model.username });
                FormsAuthentication.SetAuthCookie(model.username, model.rememberme);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("","username or password wrong!");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
           FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}