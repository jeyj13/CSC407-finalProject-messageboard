using CSC407_Final.Models;
using CSC407_Final.Services.Posting;
using CSC407_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CSC407_Final.Controllers
{
    public class ThreadController : Controller
    {
        private PostServices postService;

        public ThreadController()
        {
            this.postService = new PostServices();
    }
        //**********************************************************************************
        // GET: Thread
        public ActionResult ThreadList()
        {
            
            var threads = this.postService.GetThreads();
            return View(threads);
        }

        [HttpPost]
        public ActionResult ThreadList(FormCollection form)
        {
            var thread = this.postService.GetThreadByTitle(Request.Form["search"]);
            return View(thread);
        }


        //**********************************************************************************

        //**********************************************************************************
        // GET: Thread/Create
        public ActionResult CreateThread()
        {
            
            return View();
        }
        //**********************************************************************************
        // POST: Thread/Create
        [HttpPost]
        public ActionResult CreateThread(Thread thread)
        {
            try
            {
                this.postService.SaveThread(thread);

                return RedirectToAction("ThreadList");
            }
            catch
            {
                return View();
            }
        }
        //**********************************************************************************
        // GET: Thread/Edit/5
        public ActionResult EditThread(int id)
        {
            return View();
        }
        //**********************************************************************************
        // POST: Thread/Edit/5
        [HttpPost]
        public ActionResult EditThread(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("ThreadList");
            }
            catch
            {
                return View();
            }
        }
        //**********************************************************************************
        // GET: Thread/Delete/5
        public ActionResult DeleteThread(int id)
        {
            var OP = new CommentViewModel();
            OP.Thread = this.postService.GetThreadById(id);
            OP.Comments = this.postService.GetComments(id);
            return View(OP);
        }
        //**********************************************************************************
        // POST: Thread/Delete/5
        [HttpPost]
        public ActionResult DeleteThread(int id, FormCollection collection)
        {
            try
            {
                this.postService.DeleteThread(id);
                

                return RedirectToAction("ThreadList");
            }
            catch
            {
                
                return View();

            }
        }
        //**********************************************************************************
    }
}
