using Eshoper_CD.Areas.Admin.Models;
using Models.Framework;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshoper_CD.Areas.Admin.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Admin/Accounts
        public ActionResult Index()
        {
            var lst = new ProfileModel().GetProfiles();
            return View(lst);
        }

        public ActionResult CreateAccount()
        {
            var account = new CreateAccountModel();
            return View(account);
        }
        [HttpPost]
        public ActionResult CreateAccount(CreateAccountModel account)
        {
            if (ModelState.IsValid)
            {
                var profiles = new ProfileModel().GetAllProfiles();
                foreach(var profile in profiles)
                {
                    if(profile.username == account.username)
                    {
                        ModelState.AddModelError("", "Username already exists!");
                        return View(account);
                    }
                    if(profile.email == account.email)
                    {
                        ModelState.AddModelError("", "Email already exists!");
                        return View(account);
                    }
                }
                var newAccount = new AccountModel().CreateAccount(account.username, account.password, account.lname, account.fname, account.email);
                if(newAccount != null)
                {
                    return RedirectToAction("CompleteProfile", "Accounts", new { id = newAccount.username });
                }
            }
            return View(account);
        }

        public ActionResult CompleteProfile(string id)
        {
            var profile = new ProfileModel().GetProfileDetail(id);
            return View(profile);
        }

        [HttpPost]
        public ActionResult CompleteProfile(string id, Profile profile)
        {
            profile = new ProfileModel().UpdateProfile(id, profile.fname, profile.lname, (DateTime)profile.birthday, profile.phonenumber, profile.email, profile.Address, profile.City, profile.Country, profile.postalcode, profile.aboutme);
            return RedirectToAction("Index");
        }

        public ActionResult AccountDetail(string id)
        {
            var account = new ProfileModel().GetProfileDetail(id);
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountDetail(string id, Profile profile)
        {
                profile = new ProfileModel().UpdateProfile(id, profile.fname, profile.lname, (DateTime) profile.birthday, profile.phonenumber, profile.email, profile.Address, profile.City, profile.Country, profile.postalcode, profile.aboutme);
                if(profile != null)
                    return RedirectToAction("AccountDetail", "Accounts", new { id = id });
            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword(string id)
        {
            var account = new AccountModel().GetAccountDetail(id);
            var item = new PasswordModel()
            {
                username = account.username,
                password = account.password,
            };
            return PartialView(item);
        }

        
        [HttpPost]
        public ActionResult ChangePassword(string id, PasswordModel account)
        {
            var item = new AccountModel().ChangePassword(id, account.newpassword);
            return RedirectToAction("AccountDetail", "Accounts", new { id = id });
        }

        [HttpPost]
        public ActionResult DeleteAccount(PasswordModel account)
        {
            var item = new AccountModel().DeleteAccount(account.username);
            return RedirectToAction("Index");
        }
    }
}