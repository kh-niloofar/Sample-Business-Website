﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MYTestSite.Controllers.Account
{
    public class AccountController : Controller
    {
        Connect db = new Connect();
        private ILoginRepos loginRepos;
        public AccountController()
        {
            loginRepos = new LoginRepos(db);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login,string ReturnURL="/")
        {
            if (ModelState.IsValid)
            {
                if (loginRepos.IsExistUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return Redirect(ReturnURL);
                }
                else
                {
                    ModelState.AddModelError("UserName", "کاربری یافت نشد");
                }
            }
            return View(login);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}