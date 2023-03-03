using BotDetect.Web.Mvc;
using Eshoper_CD.Common;
using Eshoper_CD.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProfileModel = Models.Models.ProfileModel;

namespace Eshoper_CD.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Session[CommonConstants.USER_SESSION] != null && Session[CommonConstants.USER_SESSION].ToString() != "")
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var account = new AccountModel().Login(user.username, user.password);
                if (account)
                {
                    var log = new AccountModel().GetAccountDetail(user.username);
                    var userSession = new UserLogin();
                    userSession.username = log.username;
                    Session.Add(CommonConstants.USER_SESSION,userSession);
                    var check = new ProfileModel().GetProfileDetail(user.username);
                    if(check.Address == null || check.phonenumber == null)
                    {
                        ModelState.AddModelError("", "Please Complete your profile");
                        return View("Profiles");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password incorrect.");
                }
            }
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCaptcha","Incorrect Captcha Code!")]
        public ActionResult Register(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var accounts = new AccountModel().GetAccounts();
                if(user.username == "admin")
                {
                    ModelState.AddModelError("", "Username is not invalid");
                    return View("Login");
                }
                foreach(var account in accounts)
                {
                    if(user.username == account.username)
                    {
                        ModelState.AddModelError("", "Username is exists");
                        return View("Login");
                    }
                }
                if(user.password == "" || user.password != user.passwordConfirm)
                {
                    ModelState.AddModelError("", "Password is not invalid. Please check Password and Password Confirm again.");
                    return View("Login");
                }
                var newAccount = new AccountModel().CreateAccount(user.username, user.password, user.lname, user.fname, user.email);
                return Login(user);
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        public ActionResult Profiles()
        {
            if(Session[CommonConstants.USER_SESSION] == null || Session[CommonConstants.USER_SESSION].ToString() == "")
            {
                return RedirectToAction("Login", "Users");
            }
            var name = (UserLogin) Session[CommonConstants.USER_SESSION];
            var username = name.username.ToString();
            var account = new AccountModel().GetAccountDetail(username);
            var profiles = new ProfileModel().GetProfileDetail(username);
            var rs = new Models.ProfileModel()
            {
                username = account.username,
                password = account.password,
                fname = profiles.fname,
                lname = profiles.lname,
                phone = profiles.phonenumber,
                birthday = (DateTime) profiles.birthday,
                email = profiles.email,

                country = profiles.Country,
                city = profiles.City,
                address = profiles.Address,
                zip = profiles.postalcode,
                aboutme = profiles.aboutme,
            };
            return View(rs);
        }
        
        [HttpPost] 
        public ActionResult Profiles(Models.ProfileModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.newPassword != null && model.newPassword != "")
                {
                    var updatePass = new AccountModel().ChangePassword(model.username, model.newPassword);
                    model.username = updatePass.username;
                    model.password = updatePass.password;
                }
                
                var updateProfile = new ProfileModel().UpdateProfile(model.username, model.fname, model.lname, model.birthday, model.phone, model.email, model.address, model.city, model.country, model.zip, model.aboutme);
                return RedirectToAction("Profiles", "Users");
            }
            return View(model);
        }
    }
}