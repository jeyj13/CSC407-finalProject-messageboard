using CSC407_Final.Models;
using CSC407_Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC407_Final.Controllers
{
    public class UserController : Controller
    {
        private UserService userservices;

        public UserController(){
        this.userservices = new UserService();
        
    }
        // GET: User
        public ActionResult Users()
        {

            var users = this.userservices.GetUsers();
            return View(users);
        }


        public ActionResult ElevateUser(string id)
        {
            var user = this.userservices.GetUserById(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult ElevateUser(string id, FormCollection usercollection)
        {
            try
            {
                var user = this.userservices.GetUserById(id);
                this.userservices.ToAdmin(user);

                return RedirectToAction("Users");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DemoteUser(string username)
        {
            var user = this.userservices.GetUserById(username);
            return View(user);
        }

        [HttpPost]
        public ActionResult DemoteUser(FormCollection form, string id)
        {
            try
            {
                var user = this.userservices.GetUserById(id);
                this.userservices.FromAdmin(user);

                return RedirectToAction("Users");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult DeleteUser(string id)
        {
            var user = this.userservices.GetUserById(Request.Form["Username"]);
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult DeleteUser(string id, FormCollection collection)
        {
            try
            {
                var user = this.userservices.GetUserById(id);
                this.userservices.Delete(user);

                return RedirectToAction("Users");
            }
            catch
            {
                return View();
            }
        }
    }
}
