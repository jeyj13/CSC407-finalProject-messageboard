using CSC407_Final.Models;
using CSC407_Final.Services;
using CSC407_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GenevaShares.Controllers
{
    public class AccountController : Controller
    {
        private IUserServices userService;
        //********************************************************************************************************
        public AccountController()
        {
            var encryptor = new SHA256Encryptor();
            this.userService = new UserService(encryptor);
        }
        //*********************************************************************************************************
        public ActionResult Login()
        {
            return View();
        }
        //*******************************************************************************************************
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (model.Username == null || model.Password == null)
            {
                this.ModelState.AddModelError("", "Missing user input");
                return View(model);
            }
            bool isAuthenticated = this.userService.Authenticate(model.Username, model.Password);
            if (isAuthenticated)
            {
                FormsAuthentication.SetAuthCookie(model.Username, true);
                this.userService.EnableAdmin(model.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                this.ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }


        }
        //********************************************************************************************************
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //************************************************************************************************************************
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }
        //*************************************************************************************************************************
        [HttpPost]

        public ActionResult Register(User user)
        {

            bool exists = this.userService.Exists(user.Username);
            if (exists)
            {
                this.ModelState.AddModelError("", "Username already exists");
                return View();
            }
            if (user.Username == null || user.Password  == null || user.Email == null)
            {
                this.ModelState.AddModelError("", "Missing user input");
                return View();
            }
            try
            {
                this.userService.Register(user);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", "An error has occured");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        //*******************************************************************************************************************
    }
}